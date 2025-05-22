export class LoginView {
    constructor(container) {
      this.container = container;
    }
  
    renderLogin(onSubmitCallback) {
      this.container.innerHTML = '';
  
      const titulo = document.createElement('h2');
      titulo.textContent = 'Login de Usuário';
  
      const form = document.createElement('form');
  
      const inputEmail = document.createElement('input');
      inputEmail.name = 'email';
      inputEmail.placeholder = 'Email';
      inputEmail.type = 'email';
      inputEmail.required = true;
  
      const inputSenha = document.createElement('input');
      inputSenha.name = 'senha';
      inputSenha.placeholder = 'Senha';
      inputSenha.type = 'password';
      inputSenha.required = true;
  
      const botao = document.createElement('button');
      botao.type = 'submit';
      botao.textContent = 'Entrar';
  
      form.append(
        inputEmail, document.createElement('br'),
        inputSenha, document.createElement('br'),
        botao
      );
  
      this.container.appendChild(titulo);
      this.container.appendChild(form);
  
      form.addEventListener('submit', (e) => {
        e.preventDefault();
        onSubmitCallback({
          email: inputEmail.value,
          senha: inputSenha.value
        });
      });
    }
  }
  