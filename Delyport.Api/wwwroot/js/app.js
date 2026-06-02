const API_BASE = '/api';
let currentServicioId = 1; // Para la demo inicial

document.addEventListener('DOMContentLoaded', () => {
    loadSolicitudes();
    loadServicio();
    
    document.getElementById('form-editar').addEventListener('submit', function(e) {
        e.preventDefault(); saveSolicitud();
    });

    document.getElementById('form-crear').addEventListener('submit', function(e) {
        e.preventDefault(); crearSolicitud();
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

function showToast(message, isError = false) {
    const toast = document.getElementById('toast');
    toast.textContent = message;
    toast.className = 'toast show' + (isError ? ' error' : '');
    setTimeout(() => { toast.className = toast.className.replace('show', ''); }, 3000);
}

function closeModal(modalId) {
    document.getElementById(modalId).style.display = 'none';
}

/* ==============================================
   HU-002: GESTIÓN Y CREACIÓN DE SOLICITUDES
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

function openCrearModal() {
    document.getElementById('form-crear').reset();
    document.getElementById('modal-crear').style.display = 'flex';
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
        if(!response.ok) throw new Error('Error al actualizar la solicitud');
        showToast('Solicitud actualizada con éxito');
        closeModal('modal-editar');
        loadSolicitudes();
    } catch (error) {
        showToast(error.message, true);
    }
}

async function crearSolicitud() {
    const data = {
        cliente: document.getElementById('crear-cliente').value,
        detalleCarga: document.getElementById('crear-detalle').value,
        pesoKg: parseFloat(document.getElementById('crear-peso').value)
    };

    try {
        const response = await fetch(`${API_BASE}/solicitudes`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        if(!response.ok) throw new Error('Error al crear la solicitud');
        showToast('Solicitud creada con éxito');
        closeModal('modal-crear');
        loadSolicitudes();
    } catch (error) {
        showToast(error.message, true);
    }
}

/* ==============================================
   HU-005 & HU-006: SERVICIOS Y ASIGNACIONES
   ============================================== */

const estadosEnum = { 0: 'Pendiente', 1: 'Aceptado', 2: 'Rechazado', 3: 'En Proceso' };
const badgesEnum = { 0: 'badge-pending', 1: 'badge-process', 2: 'badge-process', 3: 'badge-process' };

function buscarServicio() {
    const id = document.getElementById('buscar-srv-id').value;
    if(id) {
        currentServicioId = id;
        loadServicio();
    }
}

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
        showToast('Servicio no encontrado (ID: '+currentServicioId+')', true);
        document.getElementById('srv-codigo').innerText = 'No encontrado';
        document.getElementById('srv-desc').innerText = '-';
        document.getElementById('srv-actions').innerHTML = '';
    }
}

function renderActions(estadoActual) {
    const actionsDiv = document.getElementById('srv-actions');
    actionsDiv.innerHTML = '';

    if(estadoActual === 0) { // Pendiente (HU-005)
        actionsDiv.innerHTML = `
            <button class="btn btn-success" onclick="responderAsignacion(true)">✅ Aceptar Servicio</button>
            <button class="btn btn-danger" onclick="responderAsignacion(false)">❌ Rechazar</button>
        `;
    } else {
        // Selector dinámico para HU-006 Cambio de Estado
        actionsDiv.innerHTML = `
            <div style="display:flex; gap:10px; align-items:center; width:100%">
                <select id="select-nuevo-estado" class="btn" style="background: rgba(0,0,0,0.2); color:white; border: 1px solid var(--glass-border)">
                    <option value="1" ${estadoActual === 1 ? 'selected' : ''}>Aceptado</option>
                    <option value="3" ${estadoActual === 3 ? 'selected' : ''}>En Proceso</option>
                    <option value="2" ${estadoActual === 2 ? 'selected' : ''}>Rechazado</option>
                </select>
                <button class="btn btn-primary" onclick="cambiarEstadoDesdeSelect()">🔄 Actualizar Estado</button>
            </div>
        `;
    }
}

async function responderAsignacion(aceptar) {
    const payload = { aceptar: aceptar, motivo: "", conductorId: 105 }; 
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

function cambiarEstadoDesdeSelect() {
    const nuevoEstado = parseInt(document.getElementById('select-nuevo-estado').value);
    cambiarEstado(nuevoEstado);
}

async function cambiarEstado(nuevoEstado) {
    const payload = { estadoNuevo: nuevoEstado, observacion: "Actualizado desde panel interactivo" };
    try {
        const res = await fetch(`${API_BASE}/asignaciones/${currentServicioId}/estado`, {
            method: 'PATCH',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });
        
        if(!res.ok) {
            const err = await res.json();
            throw new Error(err.message || 'Fallo al actualizar estado');
        }
        showToast('Estado actualizado correctamente (HU-006)');
        loadServicio();
    } catch (e) {
        showToast(e.message, true);
    }
}
