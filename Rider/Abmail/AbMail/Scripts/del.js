$(function() {
    var re = /^(\w)+/;

    $('table.tablestyle tr').find('td:eq(0)').each(function(i, dom) {

        if (!($(dom).contents().is("[nodeType=1]"))) {
            $(dom).text($(dom).text().replace(re, ""));
        };
    });

    $('tr.headerstyle th').each(function(i, dom) {
        if (!($(dom).contents().is("[nodeType=1]"))) {
            $(dom).text($(dom).text().replace(re, ""));
        }
        else {
            $(dom).find("a").eq(0).text($(dom).find("a").eq(0).text().replace(re, ""));
        };

    });

});