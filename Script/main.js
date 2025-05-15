const NavBar = document.getElementById('NavBar');
const conteudo = document.getElementById('conteudo');

const menuBotao = document.createElement('button');
menuBotao.textContent = 'Menu';
menuBotao.className = 'menubtn';


const cadastroBotao = document.createElement('button');
cadastroBotao.textContent = 'Cadastrar-se';
cadastroBotao.className='cadastrobtn';


const loginBotao = document.createElement('button');
loginBotao.textContent = 'Logar';
loginBotao.className = 'loginbtn';



cadastroBotao.addEventListener('click', ()=> {
    telacadastro();
});


NavBar.appendChild(menuBotao);
NavBar.appendChild(cadastroBotao);
NavBar.appendChild(loginBotao);

function telacadastro() {
    conteudo.innerHTML = `
    <h2>Cadastro de Usuário</h2>
    <form id="formCadastro">
      <label>Nome:</label><br>
      <input type="text" name="nome"><br><br>

      <label>Email:</label><br>
      <input type="email" name="email"><br><br>

      <label>Senha:</label><br>
      <input type="password" name="senha"><br><br>

      <button type="submit">Cadastrar</button>
    </form>
    `;
    const form = document.getElementById('formCadastro');
    form.addEventListener('submit', (e) => {
    e.preventDefault();
    alert('Usuário cadastrado com sucesso!');
  });
}