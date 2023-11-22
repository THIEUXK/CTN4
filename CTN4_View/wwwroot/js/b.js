$(document).ready(function () {

    $('input[name="ChatLieu"]').change(function () {
        // Kiểm tra trạng thái của checkbox
        if ($(this).is(':checked')) {
            // Lấy giá trị từ checkbox
            var chatLieuId = $(this).val();
            debugger
            // Thực hiện AJAX request khi checkbox được chọn
            $.ajax({
                url: '/XxemSanPham/layIDchatlieu', // Điền đường dẫn tương ứng khi checkbox được chọn
                type: 'POST', // Hoặc 'GET' tùy thuộc vào yêu cầu của bạn
                data: { chatLieuId: chatLieuId },
                success: function (response) {
                    // Xử lý kết quả từ server nếu cần
                    console.log(response);
                },
                error: function (error) {
                    console.error('Lỗi AJAX:', error);
                }
            });
        } else {
            // Lấy giá trị từ checkbox khi nó được bỏ chọn
            var chatLieuIdUnchecked = $(this).val();
            debugger
            // Thực hiện AJAX request khi checkbox được bỏ chọn
            $.ajax({
                url: '/XxemSanPham/boIDchatlieu', // Điền đường dẫn tương ứng khi checkbox bị bỏ chọn
                type: 'POST', // Hoặc 'GET' tùy thuộc vào yêu cầu của bạn
                data: { chatLieuId: chatLieuIdUnchecked },
                success: function (response) {
                    // Xử lý kết quả từ server nếu cần
                    console.log(response);
                },
                error: function (error) {
                    console.error('Lỗi AJAX:', error);
                }
            });
        }
    });
  

});