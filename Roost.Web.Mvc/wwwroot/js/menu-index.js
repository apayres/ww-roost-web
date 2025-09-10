$(window).on('load', function () {
    $('.addToOrder').on('click', addToOrder_Click);
    $('.optionValue').on('change', optionValue_Change);
});

function addToOrder_Click(e) {
    e.preventDefault();

    const modal = $(this).parents('.modal');

    const form = $(this).parents('.orderOptionsForm');

    const options = form.find('.option');
        
    $.ajax({
        type: "POST",
        url: '/Bag/AddToOrder',
        data: getOrderItem(form),
        contentType: 'application/json',
        cache: false
    }).done(function (response) {

        // Close the modal
        bootstrap.Modal.getInstance(modal[0]).hide();

        // Reset the options
        options.each(function (i, opt) {
            $(opt).find('option:first').prop('selected', true);
        });

        // Update bag quantity
        $('.bagFillQuantity').text(response.orderItems.length);

        // Show success message
        const toast = $('#toastMessage');
        toast.find('.toast-body').text('Item added successfully!');
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toast[0]);
        toastBootstrap.show();


    }).fail(function (err, errorText) {

        // Close the modal
        bootstrap.Modal.getInstance(modal[0]).hide();

        // Reset the options
        options.each(function (i, opt) {
            $(opt).find('option:first').prop('selected', true);
        });

        // Show failure message
        const toast = $('#toastMessage');
        toast.find('.toast-body').text('Failed to add item!');
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toast[0]);
        toastBootstrap.show();
    });

    return false;
}

function getOrderItem(form) {
    const upc = form.find('.upc').val();

    const options = [];
    form.find('.option').each(function (i, opt) {
        options.push({
            Name: $(opt).find('.optionName').text(),
            Value: $(opt).find('.optionValue').val()
        });
    });

    const quantity = form.find('.quantity').val();

    return JSON.stringify({
        Upc: upc,
        Options: options,
        Quantity: quantity
    });
}

function optionValue_Change(e) {
    const form = $(this).parents('form');

    const pigeonMilkQty = Number(form.find('.optionValue:first').val());
    const pigeonMilkCalories = Number(form.find('.pigeonMilkCalories').val()) * pigeonMilkQty;

    const sugarQty = Number(form.find('.optionValue:last').val());
    const sugarCalories = Number(form.find('.sugarCalories').val()) * sugarQty;

    const baseCalories = Number(form.find('.baseCalories').val());
    const totalCalories = baseCalories + pigeonMilkCalories + sugarCalories;

    form.find('.caloriesTotal').text(totalCalories);
}