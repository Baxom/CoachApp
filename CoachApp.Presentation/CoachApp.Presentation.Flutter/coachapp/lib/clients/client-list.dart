import 'package:flutter/material.dart';
import 'dart:convert' show json;
import 'package:http/http.dart' as http;
import 'client.dart';

class ClientsPage extends StatefulWidget {
  @override
  _ClientsPageState createState() => _ClientsPageState();
}

class _ClientsPageState extends State<ClientsPage> {
  Future<List<_Client>>? futureClients;

  @override
  void initState() {
    super.initState();
    futureClients = _fetchClients();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Liste des Clients'),
        ),
        body: FutureBuilder<List<_Client>>(
          future: futureClients,
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return const Center(child: CircularProgressIndicator());
            } else if (snapshot.hasError) {
              return const Center(child: Text('Erreur de chargement des clients'));
            } else if (snapshot.hasData) {
              return ListView.builder(
                itemCount: snapshot.data!.length,
                itemBuilder: (context, index) {
                  final client = snapshot.data![index];
                  return ListTile(
                      title: Text(client.fullName),
                      onTap: () => Navigator.push(
                            context,
                            MaterialPageRoute(builder: (context) => CreateClientPage(client.id)),
                          ).then((_) => setState(() {
                                futureClients = _fetchClients();
                              })));
                },
              );
            } else {
              return const Center(child: Text('Aucun client trouvé'));
            }
          },
        ),
        floatingActionButton: FloatingActionButton(
          onPressed: () {
            // Gérer l'action du bouton flottant ici
            // Par exemple, pour ouvrir la page de création de client :
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => CreateClientPage(null)),
            ).then((_) => setState(() {
                  futureClients = _fetchClients();
                }));
          },
          child: const Icon(Icons.add),
        ));
  }
}

Future<List<_Client>> _fetchClients() async {
  final response = await http.get(Uri.parse('https://192.168.1.21:7173/client'));
  if (response.statusCode == 200) {
    // La requête s'est bien déroulée
    Iterable decodedData = json.decode(response.body);
    List<_Client> clients = decodedData.map((clientJson) => _Client.fromJson(clientJson)).toList();
    return clients;
  } else {
    // Gérer les erreurs si besoin
    throw Exception('Erreur de chargement des clients depuis l\'API');
  }
}

class _Client {
  final String id;
  final String lastName;
  final String firstName;

  String get fullName => "$firstName $lastName";

  _Client({required this.id, required this.lastName, required this.firstName});

  factory _Client.fromJson(Map<String, dynamic> json) {
    return _Client(
      id: json['id'],
      lastName: json['lastname'],
      firstName: json['firstname'],
    );
  }
}
