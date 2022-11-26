document.getElementById('btn-imgusuario')?.click()
function MostrarFotoUsuario(fotoUsuario){
    $("#imgusuario").attr("src", "/img/"+fotoUsuario)

function MostrarFotoUsuario(fotoUsuario, nombreUsuario){
    $("#imgusuario").attr("src", "/img/" + fotoUsuario) 
    $("#nombreusuario").html(nombreUsuario)
}