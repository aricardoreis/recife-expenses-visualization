$(function () {
    $('.load-button').on('click', (e) => {
        e.preventDefault();

        let element = $(e.currentTarget);
        let action = element.data('action');

        loadTableData(action, $("#main-container"));
    });
})

function loadTableData(url, container) {
    addLoading(container);
    $.get(url, function (data) {
        container.html(data);
        container.find('table').DataTable();
    });
}

function addLoading(container) {
    let spinner = $('<div>').addClass('text-center');
    $('<div>').addClass('spinner-border').appendTo(spinner);
    container.html(spinner);
}