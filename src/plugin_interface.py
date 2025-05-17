class PluginInterface:
    def get_plugin_name(self):
        raise NotImplementedError("get_plugin_name() must be implemented")

    def get_plugin_version(self):
        raise NotImplementedError("get_plugin_version() must be implemented")

    def handle_request(self, request):
        raise NotImplementedError("handle_request() must be implemented")