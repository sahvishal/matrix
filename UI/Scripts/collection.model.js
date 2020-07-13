function collectionmodel(groupModelJObject, itemDivSelector, clearItemSelector) {
    this.GroupModelJObject = groupModelJObject;
    this.ItemParentSelector = itemDivSelector;
    this.ClearItemSelector = clearItemSelector;
    this.defineClear();
}

collectionmodel.prototype = {
    GroupModelJObject: null,
    ItemParentSelector: null,
    ClearItemSelector: null,
    addItem: function () {
        var lastItem = this.GroupModelJObject.find(this.ItemParentSelector + ":last");
        var itemDiv = lastItem.clone();
        cm_clear(itemDiv);
        
        $(itemDiv).find("input[type=text], input[type=hidden], select, input[type=checkbox]").each(function () {
            cm_incrementindex(this);
        });

        $(itemDiv).insertAfter(lastItem);
        $(itemDiv).find(".error-block").remove();
        
        this.defineClear();
    },
    removeItem: function (caller) {
        var parentDiv = $(caller).parents(this.ItemParentSelector + ":first");

        if (this.GroupModelJObject.find(this.ItemParentSelector).length > 1) {
            parentDiv.remove();
            this.correctIndex();

        } else {
            cm_clear($(caller).parents(this.ItemParentSelector + ":first"));
        }
    },
    correctIndex: function () {
        var index = 0;
        this.GroupModelJObject.find(this.ItemParentSelector).each(function () {
            
            $(this).find("input[type=text], input[type=hidden], select, input[type=checkbox]").each(function () {
                cm_changeindex(this, index);
            });
            index = index + 1;
        });
    },
    defineClear: function () {
        var obj = this;

        this.GroupModelJObject.find(this.ClearItemSelector).each(function () {
            $(this).click(function () {
                obj.removeItem($(this));
            });
        });
    }
};

function cm_incrementindex(element) {
    var prefix = cm_getNamePrefix(element);
    var suffix = cm_getNameSuffix(element);

    var index = Number(cm_getIndexValue(element)) + 1;

    $(element).attr("name", prefix + "[" + index + "]" + suffix);
}


function cm_clear(itemDivJObject) {
    itemDivJObject.find("input[type=text]").val("");
    itemDivJObject.find("input[type=hidden][name*='Id']").val("0");
    itemDivJObject.find("select").each(function () {
        $(this).find("option:first").attr("selected", "selected");
    });
    itemDivJObject.find("input[type=checkbox]").removeAttr("checked");
}


function cm_getNamePrefix(element) {
    var name = $(element).attr("name");
    var namePrefix = name.substring(0, name.indexOf("["));
    return namePrefix;
}

function cm_getIndexValue(element) {
    var name = $(element).attr("name");
    var index = name.substring(name.indexOf("[") + 1, name.indexOf("]"));
    return index;
}

function cm_getNameSuffix(element) {
    var name = $(element).attr("name");
    var nameSuffix = name.substring(name.indexOf("]") + 1, name.length);
    return nameSuffix;
}

function cm_changeindex(element, newIndex) {
    var prefix = cm_getNamePrefix(element);
    var suffix = cm_getNameSuffix(element);

    $(element).attr("name", prefix + "[" + newIndex + "]" + suffix);
}




