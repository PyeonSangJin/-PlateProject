var path = require('../../config/filepath');
var fs = require('fs');

module.exports = {
    get: function (req, res) {
        fs.exists(path.main_path + path.bundles_path + req.params.name, function (exists) {
            if (exists) {
                fs.readFile(path.main_path + path.bundles_path + req.params.name, function (err, data) {
                    var file = path.main_path + path.bundles_path + req.params.name;
                    res.download(file);
                });
            } else {
                console.log(path.main_path + path.bundles_path + req.params.name +": file not available");
                // fs.readFile(path.main_path + path.bundles_path + '/no_image.png', function (err, data) {
                //     res.end(data);
                // });
                res.end('404');
            }
        });
    }

}
