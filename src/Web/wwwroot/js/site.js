const chartTypes = {
    LINE: 0,
    PIE: 1,
    COLUMN: 2,
}

google.charts.load('current', { 'packages': ['line', 'corechart'] });

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
    $.get(url, (data) => {
        container.html(data);
        container.find('table').DataTable({
            "order": []
        });

        $('#graph-button').on('click', () => configureAndDrawChart('chart'));
    });
}

function addLoading(container) {
    let spinner = $('<div>').addClass('text-center');
    $('<div>').addClass('spinner-border').appendTo(spinner);

    container.html(spinner);
}

function configureAndDrawChart(elementId) {
    var columnName = $('#columnName').val();

    var dataTable = new google.visualization.DataTable();
    dataTable.addColumn('string', 'Data');
    dataTable.addColumn('number', 'Expenses');

    var data = loadExpenseData();
    var arrayData = [];
    for (let i = 0; i < data.length; i++) {
        arrayData.push([data[i][columnName], data[i].Value]);
    }

    dataTable.addRows(arrayData);

    var options = {
        height: 400
    };

    var chartType = parseInt($('#chartType').val());
    var chart = null;

    switch (chartType) {
        case chartTypes.LINE:
            chart = new google.charts.Line(document.getElementById(elementId));
            break;
        case chartTypes.PIE:
            chart = new google.visualization.PieChart(document.getElementById(elementId));
            break;
        case chartTypes.COLUMN:
            chart = new google.visualization.ColumnChart(document.getElementById(elementId));
            break;
    }

    chart.draw(dataTable, options);
}

function loadExpenseData() {
    return JSON.parse($('#expenseData').val());
}
