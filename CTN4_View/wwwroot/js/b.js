$(document).ready(function () 
    $('#btnXuatEx').click(function () {
        //loadTotal()
        var IdHD = this.data('id');
        if (IdHD != null {
            $.ajax({
                url: '/QuanLyHd/XuatEx',
                type: 'GET',
                dataType: 'json',
                data: {
                    IdHD: IdHD
                },
                contentType: 'application/json',
                success: function (result) {
                    if (result != null) {
                        location.href = "/ex/" + result;
                    }
                }
            });
        }
        else {
            location.reload();
        }
    });

});