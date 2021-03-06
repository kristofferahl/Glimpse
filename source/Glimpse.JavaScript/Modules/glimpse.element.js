﻿glimpse.elements = (function($) {
    var scope = $(document),
        holder, opener, pageSpacer, barHolder, panelHolder, tabHolder;
    
    return {
        scope: function () {
            return scope;
        },
        holder: function () {
            return holder || (holder = scope.find('.glimpse-holder'));
        },
        opener: function () {
            return opener || (opener = scope.find('.glimpse-open'));
        },
        pageSpacer: function () {
            return pageSpacer || (pageSpacer = scope.find('.glimpse-spacer'));
        },
        barHolder: function () {
            return barHolder || (barHolder = scope.find('.glimpse-bar'));
        },
        tabHolder: function() {
             return tabHolder || (tabHolder = scope.find('.glimpse-tabs ul'));
        },
        panelHolder: function() {
             return panelHolder || (panelHolder = scope.find('.glimpse-panel-holder'));
        },
        panel: function(key) {
             return this.panelHolder().find('.glimpse-panel[data-glimpseKey="' + key + '"]');
        },
        tab: function(key) {
             return this.tabHolder().find('.glimpse-tab[data-glimpseKey="' + key + '"]');
        },
        panels: function() {
             return this.panelHolder().find('.glimpse-panel');
        }
    };
})(jQueryGlimpse);