const express = require('express');
var app = express();

var LogController = require('../controller/LogController');

module.exports = function(){
    app.get('/log', LogController.getter);

    return app;
}