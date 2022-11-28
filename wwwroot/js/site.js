document.getElementById('btn-imgusuario')?.click()

function MostrarFotoUsuario(fotoUsuario, nombreUsuario, idUsuario){
    $("#imgusuario").attr("src", "/img/usuarios/" + fotoUsuario) 
    $("#nombreusuario").html(nombreUsuario)
    if (idUsuario == -1) $("#linkPerfil").attr("href", "/Home/IniciarSesion")
    else { // ABRIR UN MODAL
        $("#linkPerfil").attr("data-bs-toggle", "modal")
        $("#linkPerfil").attr("data-bs-target", "#modal-usuario")
        let ModalBodyUsuario = `
        Perfil: ${nombreUsuario}
        <img src="/img/usuarios/${fotoUsuario}" style="height: 10rem; margin: auto;">
        `
        $("#modal-title-usuario").html(nombreUsuario)
        $("#modal-body-usuario").html(ModalBodyUsuario)
        
    }
}


function DetalleEquipo(idEquipo){
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: '/Home/DevolverEquipo',
            data:{id: idEquipo},
            success:
                function (response){
                    $("#modal-title-equipo").html(response.nombre)
                    let modalBodyEquipo = `
                    <img src="/img/escudos/${response.escudo}" style="height: 5rem; margin: auto;"> 
                    <br>Nombre del equipo: ${response.nombre}
                    <br>Posición: ${response.pos}
                    <br>Diferencia de goles: ${response.dg}
                    <br>Partidos jugados: ${response.pj}
                    <br>Puntos totales: ${response.pts}`

                    $("#modal-body-equipo").html(modalBodyEquipo)
                }
        })
}

function DetalleJugador(idJugador){
    $.ajax(
        {
            type:'POST',
            dataType: 'json',
            url: '/Home/DevolverJugador',
            data:{id: idJugador},
            success:
                function (response){
                    $("#modal-title-jugador").html(response.nombreApellido)
                    let modalBodyJugador = `
                    <br>Goles: ${response.goles}
                    <br>Asistencia: ${response.asistencias}
                    `

                    $("#modal-body-jugador").html(modalBodyJugador)
                }
        })
}