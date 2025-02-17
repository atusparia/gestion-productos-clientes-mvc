$(document).ready(function () {


    $('#contactForm').validate({
        rules: {
            nombre: {
                required: true,
                minlength: 10,
                maxlength: 50
            },
            descripcion: {
                required: true,
                minlength: 50,
                maxlength: 200
            },
            precio: {
                required: true,
                digits: true,
                minlength: 2
            }
        },
        messages: {
            nombre: {
                required: "Por favor, ingrese el nombre",
                minlength: "El nombre debe tener mínimo 10 caracteres.",
                maxlength: "El nombre debe tener máximo 50 caracteres."
            },
            descripcion: {
                required: "Por favor, ingrese la descripción.",
                minlength: "El nombre debe tener mínimo 50 caracteres.",
                maxlength: "El nombre debe tener máximo 200 caracteres."
            },
            precio: {
                required: "Por favor, ingrese el precio.",
                digits: "El precio solo debe contener dígitos.",
                minlength: "El precio debe tener al menos 02 dígitos."
            }
        },
        submitHandler: function (form) {
            alert('Formulario enviado con éxito.');
            form.submit();
        }
    });
});