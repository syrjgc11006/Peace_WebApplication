//扩展string.Format方法
String.format = function () {
    if (arguments.length == 0)
        return null;
    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
};

$.util = {

}
$.util.getPageParams = function () {
    var pageParams = {}
    var href = location.search;
    var queryParams = href.split('&');
    for (var i = 0; i < queryParams.length; i++) {
        if (!queryParams[i] || queryParams[i].length === 1)
            continue;
        if (queryParams[i].indexOf("?") === 0) {
            queryParams[i] = queryParams[i].substring(1);
        }
        var paramArr = queryParams[i].split('=');
        pageParams[paramArr[0]] = paramArr.length > 1 ? paramArr[1] : '';
    }
    return pageParams;
}
$.util.pageParams = $.util.pageParams ? $.util.pageParams : $.util.getPageParams();
