import { LoginView } from '../../View/LoginView.js';

export class LoginController {
  constructor(container) {
    this.view = new LoginView(container);
  }

  iniciar() {
    this.view.renderLogin(this.processarLogin.bind(this));
  }

  async processarLogin(dados) {
    try {
      const resposta = await fetch('http://localhost:5066/api/usuarios/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(dados)
      });

      if (resposta.ok) {
        const resultado = await resposta.json();
        alert('Usuário logado!');
        console.log('Usuário autenticado:', resultado);
        // Aqui você pode redirecionar para outra tela
      } else if (resposta.status === 401) {
        alert('Senha incorreta!');
      } else if (resposta.status === 404) {
        alert('Usuário não encontrado. Faça seu cadastro!');
      } else {
        alert('Erro ao tentar fazer login.');
      }
    } catch (error) {
      alert('Erro de conexão com a API.');
      console.error(error);
    }
  }
}
