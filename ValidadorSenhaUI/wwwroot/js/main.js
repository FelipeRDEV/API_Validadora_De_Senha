$(function () {
    'use strict';
    function checkEmptyField() {
        $('.form-control').each(function () {
            var $field = $(this).closest('.form-group');
            if ($(this).val()) {
                $field.addClass('field--not-empty');
            } else {
                $field.removeClass('field--not-empty');
            }
        });
    }

    checkEmptyField();
    $('.form-control').on('input', function () {
        var $field = $(this).closest('.form-group');
        if (this.value) {
            $field.addClass('field--not-empty');
        } else {
            $field.removeClass('field--not-empty');
        }
    });
});