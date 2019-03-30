$(function() {
 $("input,textarea").jqBootstrapValidation({
 preventSubmit: true,
 submitError: function($form, event, errors) {
 // additional error messages or events
 },
 submitSuccess: function($form, event) {
 event.preventDefault(); // prevent default submit behaviour
 // get values from FORM
 var name = $("input#user-name").val();
 var lastname = $("input#user-lastname").val();
 var email = $("input#user-email").val();
 var phone = $("input#user-phone").val();
 var subject = $("input#user-subject").val();
 var message = $("textarea#user-message").val();
 var firstName = name; // For Success/Failure Message
 // Check for white space in name for Success/Fail message
 if (firstName.indexOf(' ') >= 0) {
 firstName = name.split(' ').slice(0, -1).join(' ');
 }
 $.ajax({
 url: "././mail/contact_me.php",
 type: "POST",
 dataType: 'json',
 data: {
 name: name,
 lastname: lastname,
 email: email,
 phone: phone,
 subject: subject,
 message: message
 },
 cache: false,
 success: function(data) {
 if(data.error){
 // Fail message
 $('#success').html("<div class='alert alert-danger'>");
 $('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;").append("</button>");
 $('#success > .alert-danger').append("<strong>Sorry " + firstName + ", Something is not right. Please try again.");
 $('#success > .alert-danger').append('</div>');
 //clear all fields
 $('#contactForm').trigger("reset");
 }
 else if(data.success){
 // Success message
 $('#success').html("<div class='alert alert-success'>");
 $('#success > .alert-success').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;").append("</button>");
 $('#success > .alert-success').append("<strong>Your message has been sent. </strong>");
 $('#success > .alert-success').append('</div>');
 //clear all fields
 $('#contactForm').trigger("reset");
 }
 }
 })
 },
 filter: function() {
 return $(this).is(":visible");
 },
 });
});


/*When clicking on Full hide fail/success boxes */
$('#name').focus(function() {
 $('#success').html('');
});
