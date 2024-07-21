$(document).ready(function () {


  $("#loginForm").validate({
    rules: {
      nombre: {
        required: true,
      },
      apellido: {
        required: true,
      },
      dni: {
        required: true,
        number: true,
      },
      correo: {
        required: true,
        email: true,
      },
      telefono: {
        required: true,
        number: true,
      },
      codPostal: {
        required: true,
        number: true,
      },
      provincia: {
        required: true,
      },
      calle: {
        required: true,
      },
      numero:{
        required:true,
        number:true,
      },
      ciudad: {
        required: true,
      },
      selectDeportes: {
        required: true,
      },
    },
    messages: {
      nombre: {
        required: "Se debe ingresar un nombre.",
      },
      apellido: {
        required: "Se debe ingresar un apellido.",
      },
      dni: {
        required: "Se debe ingresar un DNI.",
        number: "Debe ingresar un número válido.",
      },
      correo: {
        required: "Se debe ingresar un correo.",
        email: "Debe ingresar un correo válido.",
      },
      telefono: {
        required: "Se debe ingresar un teléfono.",
        number: "Debe ingresar un número válido.",
      },
      codPostal: {
        required: "Se debe ingresar un código postal.",
        number: "Debe ingresar un número válido.",
      },
      provincia: {
        required: "Se debe ingresar una provincia.",
      },
      calle: {
        required: "Se debe ingresar una calle.",
      },
      numero:{
        required: "Se debe ingresar un numero de calle.",
      },
      ciudad: {
        required: "Se debe ingresar una ciudad.",
      },
      selectDeportes: {
        required: "Debe seleccionar un deporte.",
      },
    },
    onfocusout: false,
    onkeyup: false,
/*     submitHandler: function (form) {
      window.location.href = "datos.html";
    }, */
    errorPlacement: function (error, element) {
      error.insertAfter(element);
    },
    invalidHandler: function (event, validator) {
      alert("No se pudo concretar el alta. Corrija los errores primero.");
    },
  });

  $("#loginForm input, #loginForm select").on("input change", function () {
    $(this).next(".error").text("");
  });
});
