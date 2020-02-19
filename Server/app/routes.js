var LogRouter = require('./routes/Logs');

module.exports = function(app){
    app.use('/api/log', LogRouter());
}