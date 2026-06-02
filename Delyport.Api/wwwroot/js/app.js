const API_BASE = '/api';
let currentServicioId = 1; 

document.addEventListener('DOMContentLoaded', () => {
    loadSolicitudes();
    loadServicio();
    loadHistorial();
    
    document.getElementById('form-editar').addEventListener('submit', function(e) { e.preventDefault(); saveSolicitud(); });
    document.getElementById('form-crear').addEventListener('submit', function(e) { e.preventDefault(); crearSolicitud(); });
});

function switchTab(tabId, element) {
    document.querySelectorAll('.sidebar-nav li').forEach(li => li.classList.remove('active'));
    element.classList.add('active');
    document.querySelectorAll('.tab-content').forEach(tab => tab.classList.remove('active'));
    document.getElementById(`tab-${tabId}`).classList.add('active');

    if(tabId === 'solicitudes') loadSolicitudes();
    if(tabId === 'servicios') loadServicio();
    if(tabId === 'historial') loadHistorial();
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
   HU-002: COTIZADOR MULTI-PRODUCTOS
   ============================================== */

function addProductoRow(prefix, tamano = 0, cantidad = 1) {
    const container = document.getElementById(`${prefix}-productos-container`);
    const row = document.createElement('div');
    row.className = 'producto-row';
    row.innerHTML = `
        <select class="prod-tamano" onchange="simularPrecio('${prefix}')" style="flex:1; padding:5px; border-radius:5px; background:rgba(0,0,0,0.3); color:white; border:1px solid #334155;">
            <option value="0" ${tamano == 0 ? 'selected' : ''}>Pequeño (S/3)</option>
            <option value="1" ${tamano == 1 ? 'selected' : ''}>Mediano (S/6)</option>
            <option value="2" ${tamano == 2 ? 'selected' : ''}>Grande (S/10)</option>
        </select>
        <input type="number" class="prod-cant" value="${cantidad}" min="1" oninput="simularPrecio('${prefix}')" style="width:70px; padding:5px; border-radius:5px; background:rgba(0,0,0,0.3); color:white; border:1px solid #334155;">
        <button type="button" class="btn-remove-prod" onclick="this.parentElement.remove(); simularPrecio('${prefix}')">&times;</button>
    `;
    container.appendChild(row);
    simularPrecio(prefix);
}

function getProductosFromForm(prefix) {
    const container = document.getElementById(`${prefix}-productos-container`);
    const rows = container.querySelectorAll('.producto-row');
    let productos = [];
    rows.forEach(row => {
        productos.push({
            tamano: parseInt(row.querySelector('.prod-tamano').value),
            cantidad: parseInt(row.querySelector('.prod-cant').value) || 1
        });
    });
    return productos;
}

function simularPrecio(prefix) {
    const distritoSelect = document.getElementById(`${prefix}-distrito`);
    if(!distritoSelect) return;
    const distrito = distritoSelect.options[distritoSelect.selectedIndex].text.split('(')[0].trim().toLowerCase();
    
    let tarifaBase = 50;
    if(distrito === 'santa anita') tarifaBase = 40;
    else if(distrito === 'el agustino') tarifaBase = 30;
    else if(distrito === 'comas') tarifaBase = 60;
    else if(distrito === 'callao') tarifaBase = 90;

    let sumaProductos = 0;
    const productos = getProductosFromForm(prefix);
    productos.forEach(p => {
        let pTam = p.tamano === 0 ? 3 : (p.tamano === 1 ? 6 : 10);
        sumaProductos += (pTam * p.cantidad);
    });
    
    const total = sumaProductos + (productos.length > 0 ? tarifaBase : 0);
    document.getElementById(`${prefix}-precio-ui`).innerText = total.toFixed(2);
}

async function loadSolicitudes() {
    try {
        const response = await fetch(`${API_BASE}/solicitudes/registradas`);
        if(!response.ok) throw new Error('Error al cargar solicitudes');
        const data = await response.json();
        const tbody = document.getElementById('solicitudes-tbody');
        tbody.innerHTML = '';
        if(data.length === 0) {
            tbody.innerHTML = '<tr><td colspan="6" style="text-align:center">No hay solicitudes registradas.</td></tr>';
            return;
        }

        data.forEach(sol => {
            let pStr = sol.productos.map(p => `${p.cantidad} ${p.tamano}`).join(', ');
            tbody.innerHTML += `
                <tr>
                    <td><strong>${sol.codigo}</strong></td>
                    <td>${sol.cliente}<br><small>${sol.detalleCarga}</small></td>
                    <td>${sol.distrito}<br><small>${sol.direccion}</small></td>
                    <td><small>${pStr}</small></td>
                    <td style="color:var(--success); font-weight:bold;">S/ ${sol.precioTotal.toFixed(2)}</td>
                    <td style="display:flex; gap:5px;">
                        <button class="btn btn-sm btn-primary" onclick='openEditModal(${JSON.stringify(sol)})'>Editar</button>
                        <button class="btn btn-sm btn-success" onclick='aprobarYAsignar(${sol.id})'>✅ Aprobar</button>
                    </td>
                </tr>
            `;
        });
    } catch (error) { showToast('Fallo al cargar solicitudes', true); }
}

function getTamanoValue(str) {
    if(str.includes("Peque") || str === "Pequeno" || str === "0") return 0;
    if(str.includes("Median") || str === "1") return 1;
    return 2;
}

function openEditModal(sol) {
    document.getElementById('edit-id').value = sol.id;
    document.getElementById('edit-cliente').value = sol.cliente;
    document.getElementById('edit-detalle').value = sol.detalleCarga;
    document.getElementById('edit-direccion').value = sol.direccion;
    
    const selectDistrito = document.getElementById('edit-distrito');
    for(let i=0; i<selectDistrito.options.length; i++) {
        if(selectDistrito.options[i].value === sol.distrito) selectDistrito.selectedIndex = i;
    }
    
    const container = document.getElementById('edit-productos-container');
    container.innerHTML = '';
    sol.productos.forEach(p => {
        addProductoRow('edit', getTamanoValue(p.tamano), p.cantidad);
    });
    if(sol.productos.length === 0) addProductoRow('edit');

    document.getElementById('modal-editar').style.display = 'flex';
}

function openCrearModal() {
    document.getElementById('form-crear').reset();
    document.getElementById('crear-productos-container').innerHTML = '';
    addProductoRow('crear'); // Add one default row
    document.getElementById('modal-crear').style.display = 'flex';
}

async function saveSolicitud() {
    const prods = getProductosFromForm('edit');
    if(prods.length === 0) return showToast("Agrega al menos 1 producto", true);

    const id = document.getElementById('edit-id').value;
    const data = {
        cliente: document.getElementById('edit-cliente').value,
        detalleCarga: document.getElementById('edit-detalle').value,
        direccion: document.getElementById('edit-direccion').value,
        distrito: document.getElementById('edit-distrito').value.split('(')[0].trim(),
        productos: prods
    };

    try {
        const response = await fetch(`${API_BASE}/solicitudes/${id}`, {
            method: 'PUT', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(data)
        });
        if(!response.ok) throw new Error('Error al actualizar la solicitud');
        showToast('Cotización y solicitud actualizadas');
        closeModal('modal-editar'); loadSolicitudes();
    } catch (error) { showToast(error.message, true); }
}

async function crearSolicitud() {
    const prods = getProductosFromForm('crear');
    if(prods.length === 0) return showToast("Agrega al menos 1 producto", true);

    const data = {
        cliente: document.getElementById('crear-cliente').value,
        detalleCarga: document.getElementById('crear-detalle').value,
        direccion: document.getElementById('crear-direccion').value,
        distrito: document.getElementById('crear-distrito').value.split('(')[0].trim(),
        productos: prods
    };

    try {
        const response = await fetch(`${API_BASE}/solicitudes`, {
            method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(data)
        });
        if(!response.ok) throw new Error('Error al crear la solicitud');
        showToast('Nueva solicitud generada con éxito');
        closeModal('modal-crear'); loadSolicitudes();
    } catch (error) { showToast(error.message, true); }
}

async function aprobarYAsignar(id) {
    if(!confirm("¿Convertir esta solicitud en un Servicio Asignado desde Santa Anita?")) return;
    try {
        const response = await fetch(`${API_BASE}/asignaciones/desde-solicitud/${id}`, { method: 'POST' });
        if(!response.ok) {
            const err = await response.json();
            throw new Error(err.message || 'Error al asignar');
        }
        showToast('¡Solicitud Aprobada y Asignada con éxito!');
        loadSolicitudes();
        loadHistorial();
    } catch (error) { showToast(error.message, true); }
}

/* ==============================================
   HU-005 & HU-006: HISTORIAL Y SERVICIOS
   ============================================== */
const estadosEnum = { 0: 'Pendiente', 1: 'Aceptado', 2: 'Rechazado', 3: 'En Proceso' };
const badgesEnum = { 0: 'badge-pending', 1: 'badge-process', 2: 'badge-process', 3: 'badge-process' };

async function loadHistorial() {
    try {
        const response = await fetch(`${API_BASE}/asignaciones`);
        if(!response.ok) return;
        const data = await response.json();

        const tbody = document.getElementById('historial-tbody');
        tbody.innerHTML = '';
        if(data.length === 0) {
            tbody.innerHTML = '<tr><td colspan="6" style="text-align:center">No hay servicios registrados.</td></tr>';
            return;
        }

        data.forEach(s => {
            tbody.innerHTML += `
                <tr>
                    <td>${s.id}</td>
                    <td><strong>${s.codigoServicio}</strong></td>
                    <td>${s.origen} ➡️ ${s.destino}</td>
                    <td>C-${s.conductorId}</td>
                    <td>S/${s.tarifa.toFixed(2)}</td>
                    <td><span class="badge ${badgesEnum[s.estado]}">${estadosEnum[s.estado]}</span></td>
                </tr>
            `;
        });
    } catch (error) {}
}

function buscarServicio() {
    const id = document.getElementById('buscar-srv-id').value;
    if(id) { currentServicioId = id; loadServicio(); }
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
        showToast('Servicio no encontrado', true);
        document.getElementById('srv-codigo').innerText = 'No encontrado';
        document.getElementById('srv-desc').innerText = '-';
        document.getElementById('srv-actions').innerHTML = '';
    }
}

function renderActions(estadoActual) {
    const actionsDiv = document.getElementById('srv-actions');
    actionsDiv.innerHTML = '';
    if(estadoActual === 0) { 
        actionsDiv.innerHTML = `
            <button class="btn btn-success" onclick="responderAsignacion(true)">✅ Aceptar</button>
            <button class="btn btn-danger" onclick="responderAsignacion(false)">❌ Rechazar</button>
        `;
    } else {
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
            method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(payload)
        });
        if(!res.ok) throw new Error('Fallo al responder');
        showToast(aceptar ? 'Servicio Aceptado!' : 'Servicio Rechazado');
        loadServicio();
    } catch (e) { showToast(e.message, true); }
}

function cambiarEstadoDesdeSelect() { cambiarEstado(parseInt(document.getElementById('select-nuevo-estado').value)); }

async function cambiarEstado(nuevoEstado) {
    const payload = { estadoNuevo: nuevoEstado, observacion: "Actualizado desde panel" };
    try {
        const res = await fetch(`${API_BASE}/asignaciones/${currentServicioId}/estado`, {
            method: 'PATCH', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(payload)
        });
        if(!res.ok) throw new Error('Fallo al actualizar estado');
        showToast('Historial y estado actualizados');
        loadServicio();
    } catch (e) { showToast(e.message, true); }
}
