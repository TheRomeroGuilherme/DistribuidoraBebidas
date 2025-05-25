import { Usuario } from '../Model/Usuario.js';
import { CadastroView } from '../View/CadastroView.js';

export class CadastroController {
  constructor(container) {
    this.view = new CadastroView(container);
  }

  iniciar() {
    this.view.renderFormulario(this.processarCadastro.bind(this));
  }

  processarCadastro(dados) {
    const novoUsuario = new Usuario(dados.nome, dados.email, dados.senha);
    console.log('Usuário cadastrado:', novoUsuario);
    alert('Usuário cadastrado com sucesso!');
  }
}
