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
$(document).ready(function () {

    $('input[name="MauSac"]').change(function () {
        // Kiểm tra trạng thái của checkbox
        if ($(this).is(':checked')) {
            // Lấy giá trị từ checkbox
            var mauSacId = $(this).val();
            debugger
            // Thực hiện AJAX request khi checkbox được chọn
            $.ajax({
                url: '/XxemSanPham/layIDmausac', // Điền đường dẫn tương ứng khi checkbox được chọn
                type: 'POST', // Hoặc 'GET' tùy thuộc vào yêu cầu của bạn
                data: { MauSacId: mauSacId },
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
            var mauSacIdUnchecked = $(this).val();
            debugger
            // Thực hiện AJAX request khi checkbox được bỏ chọn
            $.ajax({
                url: '/XxemSanPham/boIDmausac', // Điền đường dẫn tương ứng khi checkbox bị bỏ chọn
                type: 'POST', // Hoặc 'GET' tùy thuộc vào yêu cầu của bạn
                data: { MauSacId: mauSacIdUnchecked },
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
//////////////// loc gia tien

$(document).ready(function () {
    // Khôi phục giá trị từ Session khi trang được load lại
    //$("#minPrice").val(localStorage.getItem("minPrice") || "");
    //$("#maxPrice").val(localStorage.getItem("maxPrice") || "");
    debugger
    $('.price-input').change(function () {
        var minPrice = $("#minPrice").val();
        var maxPrice = $("#maxPrice").val();
        debugger
        if (minPrice !== null && maxPrice !== null && parseFloat(minPrice) <= parseFloat(maxPrice)) {
            // Lưu giá trị nhập liệu vào localStorage
            localStorage.setItem("minPrice", minPrice);
            localStorage.setItem("maxPrice", maxPrice);
            debugger
            $.ajax({
                url: "/XxemSanPham/layGiaLoc",
                type: "POST",
                data: { minPrice: minPrice, maxPrice: maxPrice },
                success: function (result) {
                    if (result === "ok") {
                       $("#aaa1").remove();
                    } else if (result === "that bai 1") {
                        $("#aaa1").html(`<div class="alert alert-danger">Mời bạn điền đúng giá trị</div>`);
                    }
                    // Gọi hàm cập nhật UI nếu cần
                    // updateUI(data);
                },
                error: function () {
                    alert("Đã xảy ra lỗi khi thực hiện tìm kiếm.");
                }
            });
        } else {
             $.ajax({
                url: "/XxemSanPham/XoaSsGiaTien",
                type: "POST",
                data: { minPrice: minPrice, maxPrice: maxPrice },
                success: function (result) {
                    if (result === "ok") {
                       $("#aaa1").html(`<div class="alert alert-danger">Chưa đủ điều kiện tìm</div>`);
                    } else if (result === "that bai 1") {
                        $("#aaa1").html(`<div class="alert alert-danger">Chưa đủ điều kiện tìm</div>`);
                    }
                    // Gọi hàm cập nhật UI nếu cần
                    // updateUI(data);
                },
                error: function () {
                    alert("Đã xảy ra lỗi khi thực hiện tìm kiếm.");
                }
            });
           
        }
    });
});
$(document).ready(function () {
    $('input[name="rating"]').change(function () {
        // Lấy giá trị từ radio button
        var selectedRating = $(this).val();
        debugger;

        // Thực hiện AJAX request khi radio button được chọn
        $.ajax({
            url: '/XxemSanPham/luuDanhGia', // Điền đường dẫn tương ứng khi radio button được chọn
            type: 'POST', // Hoặc 'GET' tùy thuộc vào yêu cầu của bạn
            data: { rating: selectedRating },
            success: function (response) {
                // Xử lý kết quả từ server nếu cần
                console.log(response);
            },
            error: function (error) {
                console.error('Lỗi AJAX:', error);
            }
        });
    });
});


 
