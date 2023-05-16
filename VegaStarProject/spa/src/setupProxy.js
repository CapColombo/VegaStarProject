const proxy = require('http-proxy-middleware');

module.exports = function (app) {
    const isDev = process.env.NODE_ENV === 'development';
    if (isDev) {
        app.use(
            '/api',
            proxy({
                target: 'https://localhost:5001',
                secure: false,
            }),
        );
    }
};
