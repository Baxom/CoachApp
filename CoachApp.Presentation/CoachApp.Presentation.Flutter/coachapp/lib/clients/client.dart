import 'package:flutter/material.dart';
import 'dart:convert' show json;
import 'package:http/http.dart' as http;

class CreateClientPage extends StatefulWidget {
  final String? _clientId;

  CreateClientPage(this._clientId);

  @override
  _CreateClientPageState createState() => _CreateClientPageState();
}

class _CreateClientPageState extends State<CreateClientPage> {
  TextEditingController lastNameController = TextEditingController();
  TextEditingController firstNameController = TextEditingController();
  TextEditingController birthDateController = TextEditingController();
  TextEditingController phoneController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  TextEditingController addressController = TextEditingController();

  Future<_Client?>? client;

  @override
  void initState() {
    super.initState();
    client = _fetchClient(widget._clientId);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Client'),
        ),
        body: FutureBuilder<_Client?>(
            future: client,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                lastNameController.text = snapshot.data?.lastName ?? "";
                firstNameController.text = snapshot.data?.firstName ?? "";
                birthDateController.text = snapshot.data?.birthDate ?? "";
                phoneController.text = snapshot.data?.contactDetail.phoneNumber ?? "";
                emailController.text = snapshot.data?.contactDetail.mail ?? "";

                return Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.stretch,
                    children: [
                      TextField(
                        controller: lastNameController,
                        decoration: const InputDecoration(labelText: 'Nom'),
                      ),
                      TextField(
                        controller: firstNameController,
                        decoration: const InputDecoration(labelText: 'Prénom'),
                      ),
                      TextField(
                        controller: birthDateController,
                        decoration: const InputDecoration(labelText: 'Date de naissance'),
                        keyboardType: TextInputType.datetime,
                      ),
                      TextField(
                        controller: phoneController,
                        decoration: const InputDecoration(labelText: 'Numéro de téléphone'),
                        keyboardType: TextInputType.phone,
                      ),
                      TextField(
                        controller: emailController,
                        decoration: const InputDecoration(labelText: 'Email'),
                        keyboardType: TextInputType.emailAddress,
                      ),
                      TextField(
                        controller: addressController,
                        decoration: const InputDecoration(labelText: 'Adresse postale'),
                        maxLines: 3,
                      ),
                      const SizedBox(height: 16),
                      ElevatedButton(
                        onPressed: () {
                          // Créer une instance de Client à partir des données saisies par l'utilisateur
                          final client = _Client(
                              lastName: lastNameController.text,
                              firstName: firstNameController.text,
                              birthDate: birthDateController.text,
                              contactDetail: _ContactDetail(
                                  phoneNumber: phoneController.text, mail: emailController.text),
                              address: addressController.text,
                              id: snapshot.data?.id);

                          // Enregistrer le client en utilisant l'instance de Client
                          saveClient(client);
                        },
                        child: const Text('Enregistrer'),
                      ),
                    ],
                  ),
                );
              } else {
                return const Center(child: CircularProgressIndicator());
              }
            }));
  }

  void saveClient(_Client client) async {
    final headers = <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    };

    if (client.id == null) {
      final response = await http.post(Uri.parse('https://192.168.1.21:7173/client'),
          headers: headers, body: json.encode(client));

      if (response.statusCode == 200) {
        if (!context.mounted) return;
        Navigator.pop(context);
      } else {
        // La requête a échoué
        print('Erreur HTTP ${response.statusCode}');
      }
    } else {
      final response = await http.put(Uri.parse('https://192.168.1.21:7173/client'),
          headers: headers, body: json.encode(client));

      if (response.statusCode == 200) {
        if (!context.mounted) return;
        Navigator.pop(context);
      } else {
        // La requête a échoué
        print('Erreur HTTP ${response.statusCode}');
      }
    }
  }
}

Future<_Client?> _fetchClient(String? id) async {
  if (id == null) {
    return _Client(
        lastName: '',
        firstName: '',
        birthDate: '',
        contactDetail: _ContactDetail(phoneNumber: '', mail: ''),
        address: '');
  }

  final response = await http.get(Uri.parse('https://192.168.1.21:7173/client/$id'));
  if (response.statusCode == 200) {
    // La requête s'est bien déroulée
    var u = _Client.fromJson(json.decode(response.body));

    return u;
  } else {
    // Gérer les erreurs si besoin
    throw Exception('Erreur de chargement des clients depuis l\'API');
  }
}

class _Client {
  final String? id;
  final String lastName;
  final String firstName;
  final String birthDate;
  final _ContactDetail contactDetail;
  final String address;

  _Client(
      {required this.lastName,
      required this.firstName,
      required this.birthDate,
      required this.contactDetail,
      required this.address,
      this.id});

  Map toJson() => {
        'id': id,
        'lastName': lastName,
        'firstName': firstName,
        'birthDate': birthDate,
        'contactDetails': contactDetail.toJson(),
        'address': {},
      };

  factory _Client.fromJson(Map<String, dynamic> json) {
    return _Client(
        id: json['id'],
        lastName: json['lastname'],
        firstName: json['firstname'],
        birthDate: json['birthDate'],
        contactDetail: _ContactDetail.fromJson(json['contactDetails']),
        address: '');
  }
}

class _ContactDetail {
  final String phoneNumber;
  final String mail;

  _ContactDetail({required this.phoneNumber, required this.mail});

  factory _ContactDetail.fromJson(Map<String, dynamic> json) {
    return _ContactDetail(phoneNumber: json['phoneNumber'], mail: json['mail']);
  }

  Map toJson() => {'phoneNumber': phoneNumber, 'mail': mail};
}
