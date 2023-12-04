import 'package:flutter/material.dart';
import 'dart:convert' show jsonEncode;
import 'package:http/http.dart' as http;
import 'package:coachapp/clients/client-list.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _formKey = GlobalKey<FormState>();
  String _email = "gillier.benoit@yahoo.fr";
  String _password = "Isimedi@BG+8";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Login Page'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            children: <Widget>[
              TextFormField(
                initialValue: _email,
                validator: (value) {
                  if (value?.isEmpty ?? true) {
                    return 'Please enter your email';
                  }
                  return null;
                },
                onChanged: (value) {
                  _email = value;
                },
                decoration: const InputDecoration(
                  labelText: 'Email',
                ),
              ),
              TextFormField(
                initialValue: _password,
                validator: (value) {
                  if (value?.isEmpty ?? true) {
                    return 'Please enter your password';
                  }
                  return null;
                },
                onChanged: (value) {
                  _password = value;
                },
                obscureText: true,
                decoration: const InputDecoration(
                  labelText: 'Password',
                ),
              ),
              const SizedBox(height: 20.0),
              ElevatedButton(
                onPressed: () async {
                  if (_formKey.currentState?.validate() ?? false) {
                    final headers = <String, String>{
                      'Content-Type': 'application/json; charset=UTF-8',
                    };
                    final body = {'email': _email, 'password': _password};
                    final response = await http.post(
                        Uri.parse('https://192.168.1.21:7173/user/login'),
                        headers: headers,
                        body: jsonEncode(body));
                    if (response.statusCode == 200) {
                      if (!context.mounted) return;
                      Navigator.pushReplacement(
                        context,
                        MaterialPageRoute(builder: (context) => ClientsPage()),
                      );
                    } else {
                      // La requête a échoué
                      print('Erreur HTTP ${response.statusCode}');
                    }
                  }
                },
                child: const Text('Login'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
