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

    $(document).ready(function () {
        $('#btnThuTucThanhToan').click(function () {
            var selectedIds = [];

            $('.productCheckbox:checked').each(function () {
                var productId = $(this).data('id');
                selectedIds.push(productId);
            });
            debugger
            // Kiểm tra nếu có ít nhất một sản phẩm được chọn
            if (selectedIds.length > 0) {
                var url = '/CheckOut/ChotGio'; // Điền đúng đường dẫn và tên action của bạn

                $.ajax({
                    url: url,
                    type: 'POST',
                    data: { selectedIds: selectedIds },
                    success: function (result) {
                        debugger
                        // Xử lý kết quả Ajax thành công (nếu cần)
                        console.log(result);
                        window.location.href = '/BanHang/ThuTuc'; // Điền đúng đường dẫn và tên action của bạn

                        // Thực hiện các bước tiếp theo, chẳng hạn như chuyển hướng hoặc xử lý đặt hàng
                    },
                    error: function (error) {
                        debugger
                        // Xử lý lỗi Ajax (nếu cần)
                        console.error('Error:', error);
                    }
                });
            } else {
                console.log('Không có sản phẩm được chọn.');
                $('#alertMessage').addClass('red-alert').html('Không có sản phẩm nào được chọn. Vui lòng chọn ít nhất một sản phẩm để tiếp tục.').show();
                // Nếu không có sản phẩm được chọn, có thể hiển thị thông báo hoặc thực hiện hành động khác mà bạn muốn
                // Ngăn chặn sự kiện mặc định của nút để tránh chuyển trang
                return false;
            }
        });
    });

 
    $(document).ready(function () {
        $(document).ready(function () {
            // Bắt sự kiện khi ô checkbox được thay đổi
            $('.selectAll').on('change', function () {
                // Kiểm tra xem checkbox có được tích hay không
         
                    // Gọi hàm AJAX khi checkbox được tích
                    var selectedCheckboxes = getSelectedCheckboxes();

                    // Gửi yêu cầu AJAX để xử lý danh sách đã lấy

                    $.ajax({
                        url: '/CheckOut/TinhTongTien', // Đặt URL thực hiện hành động cần thiết
                        type: 'POST', // Hoặc 'GET' tùy thuộc vào hành động của bạn
                        data: { selectedIds: selectedCheckboxes }, // Dữ liệu bạn muốn gửi
                        success: function (result) {
                            var x1 = result;
                            x1 = x1.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                            debugger
                            $('#TongTien').text(x1);
                        },
                        error: function (error) {
                            // Xử lý lỗi nếu có
                        }
                    });
                
            });
            $('.productCheckbox').on('change', function () {
                // Gọi hàm để lấy danh sách các ô checkbox được tích
                var selectedCheckboxes = getSelectedCheckboxes();

                // Gửi yêu cầu AJAX để xử lý danh sách đã lấy
              
                $.ajax({
                    url: '/CheckOut/TinhTongTien', // Đặt URL thực hiện hành động cần thiết
                    type: 'POST', // Hoặc 'GET' tùy thuộc vào hành động của bạn
                    data: { selectedIds: selectedCheckboxes }, // Dữ liệu bạn muốn gửi
                    success: function (result) {
                        var x1 = result;
                        x1 = x1.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                        debugger
                        $('#TongTien').text(x1);
                    },
                    error: function (error) {
                        // Xử lý lỗi nếu có
                    }
                });
            });

            // Hàm để lấy danh sách các ô checkbox được tích
            function getSelectedCheckboxes() {
                var selectedCheckboxes = [];

                // Duyệt qua tất cả các ô checkbox và kiểm tra xem chúng có được tích hay không
                $('.productCheckbox').each(function () {
                    if ($(this).is(':checked')) {
                        // Nếu được tích, thêm giá trị data-id vào mảng
                        selectedCheckboxes.push($(this).data('id'));
                    }
                });

                return selectedCheckboxes;
            }
        });
    });
});



