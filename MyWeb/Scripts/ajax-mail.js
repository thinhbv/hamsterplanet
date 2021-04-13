$(function() {

	// Get the form.
	var form = $('#contact-form');

	// Get the messages div.
	var formMessages = $('.form-message');

	// Set up an event listener for the contact form.
	$(form).submit(function(e) {
		// Stop the browser from submitting the form.
		e.preventDefault();

		// Serialize the form data.
		var formData = $(form).serialize();
        if ($("#name").val().trim() === '') {
            alert('Vui lòng nhập tên của bạn!');
            $("#name").attr('style', 'border-color:#ff6600');
            $("#name").focus();
            return false;
        }

        if ($("#phone").val().trim() === '') {
            alert('Vui lòng nhập số điện thoại của bạn!');
            $("#phone").focus();
            return false;
        }

        if ($("#detail").val().trim() === '') {
            alert('Vui lòng nhập nội dung của bạn!');
            $("#detail").focus();
            return false;
        }
		// Submit the form using AJAX.
		$.ajax({
			type: 'POST',
			url: $(form).attr('action'),
			data: formData
		})
		.done(function(response) {
			// Make sure that the formMessages div has the 'success' class.
			$(formMessages).removeClass('error');
			$(formMessages).addClass('success');

			// Set the message text.
            $(formMessages).text("Cảm ơn bạn đã liên hệ. Chúng tôi sẽ phản hồi trong thời gian sớm nhất.");

			// Clear the form.
			$('#contact-form input,#contact-form textarea').val('');
		})
		.fail(function(data) {
			// Make sure that the formMessages div has the 'error' class.
			$(formMessages).removeClass('success');
			$(formMessages).addClass('error');

			// Set the message text.
			if (data.responseText !== '') {
				$(formMessages).text(data.responseText);
			} else {
                $(formMessages).text('Xin lỗi bạn! Đã có lỗi xảy ra. Bạn vui lòng thử lại!');
			}
		});
	});

});
