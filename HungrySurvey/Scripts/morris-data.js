$(function() {

    Morris.Area({
        element: 'morris-area-chart',
        data: [{
            period: '2010 Q1',
            russo: 2666,
            ru: null,
            panoramico: 2647
        }, {
            period: '2010 Q2',
            russo: 2778,
            ru: 2294,
            panoramico: 2441
        }, {
            period: '2010 Q3',
            russo: 4912,
            ru: 1969,
            panoramico: 2501
        }, {
            period: '2010 Q4',
            russo: 3767,
            ru: 3597,
            panoramico: 5689
        }, {
            period: '2011 Q1',
            russo: 6810,
            ru: 1914,
            panoramico: 2293
        }, {
            period: '2011 Q2',
            russo: 5670,
            ru: 4293,
            panoramico: 1881
        }, {
            period: '2011 Q3',
            russo: 4820,
            ru: 3795,
            panoramico: 1588
        }, {
            period: '2011 Q4',
            russo: 15073,
            ru: 5967,
            panoramico: 5175
        }, {
            period: '2012 Q1',
            russo: 10687,
            ru: 4460,
            panoramico: 2028
        }, {
            period: '2012 Q2',
            russo: 8432,
            ru: 5713,
            panoramico: 1791
        }],
        xkey: 'period',
        ykeys: ['russo', 'ru', 'panoramico'],
        labels: ['Russo', 'RU', 'Panoramico'],
        pointSize: 2,
        hideHover: 'auto',
        resize: true
    });

    Morris.Donut({
        element: 'morris-donut-chart',
        data: [{
            label: "Russo",
            value: 12
        }, {
            label: "RU",
            value: 30
        }, {
            label: "Panoramico",
            value: 20
        }],
        resize: true
    });
});
