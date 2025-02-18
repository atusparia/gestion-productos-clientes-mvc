$(document).ready(function () {


    $('#crearClienteForm').validate({
        rules: {
            nombre: {
                required: true,
                minlength: 10,
                maxlength: 50
            },
            correo: {
                required: true,
                minlength: 50,
                maxlength: 200
            }
        },
        messages: {
            nombre: {
                required: "Por favor, ingrese el nombre",
                minlength: "El nombre debe tener mínimo 10 caracteres.",
                maxlength: "El nombre debe tener máximo 50 caracteres."
            },
            correo: {
                required: "Por favor, ingrese la descripción.",
                minlength: "El nombre debe tener mínimo 50 caracteres.",
                maxlength: "El nombre debe tener máximo 200 caracteres."
            }
        },
        submitHandler: function (form) {
            alert('Formulario enviado con éxito.');
            form.submit();
        }
    });
});