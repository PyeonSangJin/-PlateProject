var LogRouter = require('./routes/Logs');
var BundleRouter = require('./routes/Bundles');

module.exports = function(app){
    app.use('/api/log', LogRouter());
    app.use('/api/bundle', BundleRouter());
}