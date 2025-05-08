export class CadastroView {
    constructor(container) {
      this.container = container;
    }
  
    renderFormulario(onSubmitCallback) {
      this.container.innerHTML = '';
  
      const titulo = document.createElement('h2');
      titulo.textContent = 'Cadastro de Usuário';
  
      const form = document.createElement('form');
  
      const inputNome = document.createElement('input');
      inputNome.name = 'nome';
      inputNome.placeholder = 'Nome';
  
      const inputEmail = document.createElement('input');
      inputEmail.name = 'email';
      inputEmail.placeholder = 'Email';
      inputEmail.type = 'email';
  
      const inputSenha = document.createElement('input');
      inputSenha.name = 'senha';
      inputSenha.placeholder = 'Senha';
      inputSenha.type = 'password';
  
      const botao = document.createElement('button');
      botao.type = 'submit';
      botao.textContent = 'Cadastrar';
  
      form.append(inputNome, document.createElement('br'),
                  inputEmail, document.createElement('br'),
                  inputSenha, document.createElement('br'),
                  botao);
  
      this.container.appendChild(titulo);
      this.container.appendChild(form);
  
      form.addEventListener('submit', (e) => {
        e.preventDefault();
        onSubmitCallback({
          nome: inputNome.value,
          email: inputEmail.value,
          senha: inputSenha.value
        });
      });
    }
  }
  