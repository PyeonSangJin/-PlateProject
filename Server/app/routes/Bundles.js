const express = require('express');
var app = express();

var BundleController = require('../controller/BundleController');

module.exports = function(){
    app.post('/', BundleController.get);

    return app;
}