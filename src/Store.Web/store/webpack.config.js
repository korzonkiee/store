const path = require('path');
module.exports = {
  entry: './src/index.tsx',
  output: {
    path: path.resolve('dist'),
    publicPath: "/dist/",
    filename: 'bundle.js'
  },
  devtool: "source-map",
  resolve: {
    // Add '.ts' and '.tsx' as resolvable extensions.
    extensions: [".webpack.js", ".web.js", ".ts", ".tsx", ".js", ".jsx"] 
  },
  module: {
    loaders: [
      {
        test: /\.ts|\.tsx$/, loader: 'awesome-typescript-loader'
      },
      {
        test: /\.(ts|tsx)?$/,
        enforce: "pre",
        loader: "tslint-loader",
        options: {
            failOnHint: true,
            configFile: "./tslint.json"
        }
      }
    ]
  }
}