$(document).ready(function () {

        $(document).ready(function () {
        var emailInput = $('#emailInput');
        var emailValidationMessage = $('#emailValidationMessage');

        emailInput.on('input', function () {
            var emailValue = emailInput.val();
        var isValid = validateEmail(emailValue);

        if (isValid) {
            emailValidationMessage.text(''); // Xóa thông báo nếu hợp lệ
            } else {
            emailValidationMessage.text('Email không hợp lệ');
            }
        });

        function validateEmail(email) {
            // Thêm logic kiểm tra email ở đây
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
        }
    });

});



