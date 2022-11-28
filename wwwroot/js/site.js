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



