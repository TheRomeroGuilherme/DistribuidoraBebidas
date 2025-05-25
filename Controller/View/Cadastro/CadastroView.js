export class CadastroView {
  constructor(container) {
    this.container = container;
  }

  renderCadastro(onSubmitCallback) {
    this.container.innerHTML = '';

    const titulo = document.createElement('h2');
    titulo.textContent = 'Cadastro de Usuário';

    const form = document.createElement('form');
    form.className = 'form-cadastro';

    const inputNome = document.createElement('input');
    inputNome.name = 'nome';
    inputNome.placeholder = 'Nome';
    inputNome.required = true;
    inputNome.className = 'input-text';

    const inputEmail = document.createElement('input');
    inputEmail.name = 'email';
    inputEmail.placeholder = 'Email';
    inputEmail.type = 'email';
    inputEmail.required = true;
    inputEmail.className = 'input-text';

    const inputSenha = document.createElement('input');
    inputSenha.name = 'senha';
    inputSenha.placeholder = 'Senha';
    inputSenha.type = 'password';
    inputSenha.required = true;
    inputSenha.className = 'input-text';

    const botao = document.createElement('button');
    botao.type = 'submit';
    botao.textContent = 'Cadastrar';
    botao.className = 'btn-submit';

    const mensagem = document.createElement('p');
    mensagem.className = 'mensagem-feedback'; 

    form.append(
      inputNome, document.createElement('br'),
      inputEmail, document.createElement('br'),
      inputSenha, document.createElement('br'),
      botao
    );

    this.container.appendChild(titulo);
    this.container.appendChild(form);
    this.container.appendChild(mensagem);

    form.addEventListener('submit', (e) => {
      e.preventDefault();
      onSubmitCallback({
        nome: inputNome.value,
        email: inputEmail.value,
        senha: inputSenha.value
      });


      mensagem.textContent = 'Usuário cadastrado com sucesso!';
      mensagem.style.color = 'green';

      form.reset();
    });
  }
}
