const path = require('path');
const webpack = require('webpack');

let ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
    entry: {
        vendor: [
            'axios',
            'babel-polyfill',
            'luxon',
            'vue',
            'vuex',
            'vee-validate',
            'bootstrap-vue',
            './src/styles/bootstrap-settings.scss'
        ]
    },

    output: {
        path: path.resolve(__dirname, "dist"),
        filename: '[name].js',
        library: '[name]_dll'
    },

    module: {
        rules: [
            {
                test: /\.css(\?|$)/,
                use: ExtractTextPlugin.extract({
                    use: 'css-loader?minimize'
                })
            },
            {
                test: /\.scss$/,
                use: ExtractTextPlugin.extract({
                    use: 'css-loader!sass-loader'
                })
            },
            {
                test: /\.sass$/,
                use: ExtractTextPlugin.extract({
                    use: 'css-loader!sass-loader?indentedSyntax'
                })
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    loaders: {
                        'scss': ExtractTextPlugin.extract({
                            use: 'css-loader!sass-loader',
                            fallback: 'vue-style-loader'
                        }),
                        'sass': ExtractTextPlugin.extract({
                            use: 'css-loader!sass-loader?indentedSyntax',
                            fallback: 'vue-style-loader'
                        }),
                        'css': ExtractTextPlugin.extract({
                            use: 'css-loader',
                            fallback: 'vue-style-loader'
                        })
                    }
                }
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/,
                use: 'url-loader?limit=100000'
            }
        ]
    },

    plugins: [
        new ExtractTextPlugin("vendor.css"),
        new webpack.DllPlugin({
            path: path.join(__dirname, "dll", "[name]-manifest.json"),
            name: '[name]_dll'
        })
    ]
};

module.exports.devtool = '#source-map';
module.exports.plugins = (module.exports.plugins || []).concat([
  new webpack.optimize.UglifyJsPlugin({
    sourceMap: true,
    compress: {
      warnings: false
    }
  }),
  new webpack.LoaderOptionsPlugin({
    minimize: true
  })
]);
