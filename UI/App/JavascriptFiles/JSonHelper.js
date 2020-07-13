function correctDateExpression(dateField) {
    if (dateField == null) return null;
    var returnValue = null;
    var expr = null;
    eval("expr = " + dateField + ";");
    eval("returnValue = new " + expr.source + ";");

    returnValue = new Date(returnValue.getUTCFullYear(), returnValue.getUTCMonth(), returnValue.getUTCDate(), returnValue.getUTCHours(), returnValue.getUTCMinutes(), returnValue.getUTCSeconds(), 0);

    return returnValue;
}

