var exibirRota;
var servico = new google.maps.DirectionsService();
var servicoDistancia = new google.maps.DistanceMatrixService();

//Variável que contem o viewmodel da tela.
var ViewModel = function () {
    var self = this;
    self.listaPontos = ko.observableArray([]);
    self.listaParadas = ko.observableArray([]);
    self.listaDestinos = ko.observableArray([]);
    self.origem = ko.observable("");
    self.destino = ko.observable("");
    self.distancia = ko.observable("");
    self.tempo = ko.observable("");

    //Carrega os pontos já roteirizados que foram armazenados no backend.
    function obterPontos() {
        $.ajax({
            type: "POST",
            url: "/Rota/ObterPontos",
            success: function (data) {
                if (!data.Erro)
                    self.listaPontos(data);
                else
                    alert(data.Mensagem);
            },
            dataType: "json"
        });
    }

    //Salva a rota no banco de dados.
    function salvarRota(rota) {
        $.ajax({
            type: "POST",
            url: "/Rota/SalvarRota",
            data: rota,
            success: function (data) {
                if (data.Erro)
                    alert(data.Mensagem);
            },
            dataType: "json"
        });
    }

    obterPontos();

    //Adiciona uma nova parada ao roteiro.
    self.adicionarParada = function (item, event) {
        self.listaParadas.push({ location: "", stopover: true });
    }

    //Calcula e salva a rota solicitada pelo usuário.
    self.calcularRota = function (item, event) {
        if (!self.origem()) {
            alert("É necessário preencher a Origem!");
        }

        if (!self.destino()) {
            alert("É necessário preencher o Destino!");
        }

        //Objeto de requisição com dados da rota.
        var request = {
            origin: self.origem(),
            destination: self.destino(),
            travelMode: google.maps.DirectionsTravelMode.DRIVING,
            waypoints: self.listaParadas()
        };

        //Executa a chamada ao roteamento.
        servico.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                exibirRota.setDirections(response);
            }
        });

        //Limpa o array de destinos antes de realimenta-lo.
        //Necessário para salvar os pontos no banco e calcular distância e tempo.
        self.listaDestinos([]);

        for (var i = 0; i < self.listaParadas().length; i++)
            self.listaDestinos.push(self.listaParadas()[i].location);

        //Objeto que é esperado no backend para salvar a rota.
        var rota = {
            Origem: self.origem(),
            Destino: self.destino(),
            Paradas: self.listaDestinos()
        }

        salvarRota(rota);

        //Calcula a distância e o tempo.
        servicoDistancia.getDistanceMatrix(
            {
                origins: [self.origem()],
                destinations: self.listaDestinos().concat([self.destino()]),
                travelMode: google.maps.TravelMode.DRIVING,
                unitSystem: google.maps.UnitSystem.METRIC
            },
            function atualizaDistancia(response, status) {
                var dados = response.rows[0].elements;
                self.distancia(dados[dados.length - 1].distance.text);
                self.tempo(dados[dados.length - 1].duration.text);
            });
    }
};

//Inicializa a viewmodel do knockout.js.
function IniciaKnockout() {   
    ko.applyBindings(ViewModel());
}

//Exibe o mapa na tela.
function IniciarMapa(mapContainder) {
    exibirRota = new google.maps.DirectionsRenderer();
    var latlng = new google.maps.LatLng(-15.682543, -47.978874);
    var mapType = google.maps.MapTypeId.ROADMAP;
    var opcoes =
    {
        zoom: 8,
        center: latlng,
        mapTypeId: mapType
    };
    var mapa = new google.maps.Map(mapContainder, opcoes);
    exibirRota.setMap(mapa);
}