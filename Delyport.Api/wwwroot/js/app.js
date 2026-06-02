const API_BASE = '/api';
let currentServicioId = 1; // Para la demo asumimos el servicio 1

document.addEventListener('DOMContentLoaded', () => {
    loadSolicitudes();
    loadServicio();
    
    document.getElementById('form-editar').addEventListener('submit', function(e) {
        e.preventDefault();
        saveSolicitud();
    });
});

// Cambiar de Pestaña
function switchTab(tabId, element) {
    document.querySelectorAll('.sidebar-nav li').forEach(li => li.classList.remove('active'));
    element.classList.add('active');
    
    document.querySelectorAll('.tab-content').forEach(tab => tab.classList.remove('active'));
    document.getElementById(`tab-${tabId}`).classList.add('active');

    if(tabId === 'solicitudes') loadSolicitudes();
    if(tabId === 'servicios') loadServicio();
}

// Mostrar Toast
function showToast(message, isError = false) {
    const toast = document.getElementById('toast');
    toast.textContent = message;
    toast.className = 'toast show' + (isError ? ' error' : '');
    setTimeout(() => { toast.className = toast.className.replace('show', ''); }, 3000);
}

/* ==============================================
   HU-002: GESTIÓN DE SOLICITUDES
   ============================================== */

async function loadSolicitudes() {
    try {
        const response = await fetch(`${API_BASE}/solicitudes/registradas`);
        if(!response.ok) throw new Error('Error al cargar solicitudes');
        const data = await response.json();
        
        const tbody = document.getElementById('solicitudes-tbody');
        tbody.innerHTML = '';
        
        if(data.length === 0) {
            tbody.innerHTML = '<tr><td colspan="5" style="text-align:center">No hay solicitudes registradas.</td></tr>';
            return;
        }

        data.forEach(sol => {
            tbody.innerHTML += `
                <tr>
                    <td><strong>${sol.codigo}</strong></td>
                    <td>${sol.cliente}</td>
                    <td>${sol.detalleCarga}</td>
                    <td>${sol.pesoKg} kg</td>
                    <td>
                        <button class="btn btn-sm btn-primary" onclick='openEditModal(${JSON.stringify(sol)})'>Editar</button>
                    </td>
                </tr>
            `;
        });
    } catch (error) {
        console.error(error);
        showToast('Fallo al cargar solicitudes', true);
    }
}

function openEditModal(sol) {
    document.getElementById('edit-id').value = sol.id;
    document.getElementById('edit-cliente').value = sol.cliente;
    document.getElementById('edit-detalle').value = sol.detalleCarga;
    document.getElementById('edit-peso').value = sol.pesoKg;
    document.getElementById('modal-editar').style.display = 'flex';
}

function closeModal() {
    document.getElementById('modal-editar').style.display = 'none';
}

async function saveSolicitud() {
    const id = document.getElementById('edit-id').value;
    const data = {
        cliente: document.getElementById('edit-cliente').value,
        detalleCarga: document.getElementById('edit-detalle').value,
        pesoKg: parseFloat(document.getElementById('edit-peso').value)
    };

    try {
        const response = await fetch(`${API_BASE}/solicitudes/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if(!response.ok) {
            const err = await response.json();
            throw new Error(err.message || 'Error al actualizar');
        }

        showToast('Solicitud actualizada con éxito');
        closeModal();
        loadSolicitudes();
    } catch (error) {
        showToast(error.message, true);
    }
}

/* ==============================================
   HU-005 & HU-006: SERVICIOS Y ASIGNACIONES
   ============================================== */

const estadosEnum = { 0: 'Pendiente', 1: 'Aceptado', 2: 'Rechazado', 3: 'En Proceso' };
const badgesEnum = { 0: 'badge-pending', 1: 'badge-process', 2: 'badge-process', 3: 'badge-process' }; // Colores simplificados

async function loadServicio() {
    try {
        const response = await fetch(`${API_BASE}/asignaciones/${currentServicioId}`);
        if(!response.ok) throw new Error('Servicio no encontrado');
        const srv = await response.json();

        document.getElementById('srv-codigo').innerText = srv.codigoServicio;
        document.getElementById('srv-desc').innerText = srv.descripcion;
        document.getElementById('srv-origen').innerText = srv.origen;
        document.getElementById('srv-destino').innerText = srv.destino;
        document.getElementById('srv-tarifa').innerText = srv.tarifa.toFixed(2);
        
        const badge = document.getElementById('srv-estado');
        badge.innerText = estadosEnum[srv.estado];
        badge.className = `badge ${badgesEnum[srv.estado]}`;

        renderActions(srv.estado);
    } catch (error) {
        document.getElementById('srv-desc').innerText = "Error: no se pudo obtener el servicio. Verifica que la BD esté actualizada.";
    }
}

function renderActions(estado) {
    const actionsDiv = document.getElementById('srv-actions');
    actionsDiv.innerHTML = '';

    if(estado === 0) { // Pendiente (HU-005)
        actionsDiv.innerHTML = `
            <button class="btn btn-success" onclick="responderAsignacion(true)">✅ Aceptar Servicio</button>
            <button class="btn btn-danger" onclick="responderAsignacion(false)">❌ Rechazar</button>
        `;
    } else if(estado === 3) { // En Proceso (Para probar HU-006 Cambio de Estado)
        // Agregamos un botón para pasarlo a algún otro estado, por ej Aceptado para simular.
        actionsDiv.innerHTML = `
            <button class="btn btn-primary" onclick="cambiarEstado(1)">🔄 Marcar como Aceptado (HU-006)</button>
        `;
    } else {
        actionsDiv.innerHTML = `<p style="color:var(--text-secondary); font-size:0.9rem">No hay acciones disponibles para este estado.</p>`;
    }
}

async function responderAsignacion(aceptar) {
    const payload = { aceptar: aceptar, motivo: "", conductorId: 105 }; // Datos simulados
    try {
        const res = await fetch(`${API_BASE}/asignaciones/${currentServicioId}/responder`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });
        
        if(!res.ok) throw new Error('Fallo al responder');
        showToast(aceptar ? 'Servicio Aceptado!' : 'Servicio Rechazado');
        loadServicio();
    } catch (e) {
        showToast(e.message, true);
    }
}

async function cambiarEstado(nuevoEstado) {
    const payload = { estadoNuevo: nuevoEstado, observacion: "Actualizado desde panel" };
    try {
        const res = await fetch(`${API_BASE}/asignaciones/${currentServicioId}/estado`, {
            method: 'PATCH',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });
        
        if(!res.ok) throw new Error('Fallo al actualizar estado');
        showToast('Estado actualizado y guardado en historial (HU-006)');
        loadServicio();
    } catch (e) {
        showToast(e.message, true);
    }
}
