interface Configuration {
    authEndpoint: string;
    authSecret: string;
    apiEndpoint: string;
    facebookAppId: string;
}

const config: Configuration = {
    authEndpoint: 'http://localhost:5000',
    authSecret: 'secret',
    apiEndpoint: 'http://localhost:5005',
    facebookAppId: '166348153966845'
};

export default config;