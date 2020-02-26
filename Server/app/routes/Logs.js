const express = require('express');
var app = express();

var LogController = require('../controller/LogController');

module.exports = function(){
    app.post('/insertlog', LogController.insertLog);

    return app;
}