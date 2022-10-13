
jQuery(function ($) {
    $("#money").inputmask('currency', {
        "autoUnmask": true,
        radixPoint: ",",
        groupSeparator: ".",
        allowMinus: false,
        prefix: 'R$ ',
        digits: 0,
        digitsOptional: false,
        rightAlign: false,
        unmaskAsNumber: true,
        removeMaskOnSubmit: true
    });
});

