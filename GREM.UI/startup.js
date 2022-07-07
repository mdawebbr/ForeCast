// const path = require('path');
// const express = require('express');
// const http = require('http');

// const app = express();
// const port = process.env.PORT || 3001;

// app.use(express.static(__dirname + '/dist/grem'));

// app.get('/*', (req, res) => res.sendFile(path.join(__dirname)));

// const server = http.createServer(app);
// server.listen(port, () => console.log('Running'));

const express = require('express');
const http = require('http');
const app = express();

// Set name of directory where angular distribution files are stored
const dist = 'dist';

// Set port
const port = process.env.PORT || 4201;

// Serve static assets
app.get('*.*', express.static(dist, { maxAge: '1y' }));

// Serve application paths
app.all('*', function (req, res) {
  res.status(200).sendFile(`/grem`, { root: dist });
});

// Create server to listen for connections
const server = http.createServer(app);
server.listen(port, () => console.log("Node Express server for " + app.name + " listening on port " + port));