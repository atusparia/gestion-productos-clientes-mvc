$(document).ready(function () {


    $('#crearProductoForm').validate({
        rules: {
            nombre: {
                required: true,
                minlength: 3,
                //maxlength: 255
            },
            precio: {
                required: true,
                digits: true,
                min: 0.01
            },
            stock: {
                required: true,
                digits: true,
                min: 1
            }
        },
        messages: {
            nombre: {
                required: "Por favor, ingrese el nombre",
                minlength: "El nombre debe tener mínimo 3 caracteres.",
                //maxlength: "El nombre debe tener máximo 255 caracteres."
            },
            precio: {
                required: "Por favor, ingrese el precio.",
                digits: "El precio solo debe contener dígitos.",
                minlength: "El precio debe ser mayor que 0"
            },
            stock: {
                required: "Por favor, ingrese el stock.",
                digits: "El stock solo debe contener dígitos.",
                minlength: "El stock debe tener al menos 01 dígitos."
            }
        },
        submitHandler: function (form) {
            Swal.fire({
                title: "¿Estás seguro?",
                text: "¿Deseas agregar este producto?",
                icon: "question",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Sí, agregar",
                cancelButtonText: "Cancelar"
            }).then((result) => {
                if (result.isConfirmed) {
                    CreateProducto();
                }
            });
        }
    });
});