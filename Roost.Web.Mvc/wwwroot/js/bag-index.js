$(window).on('load', function () {
    $('#placeOrderForm').validate({
        rules: {
            name: {
                required: true
            }
        }
    });
});