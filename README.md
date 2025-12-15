# 📐 Biblioteca de Operações com Matrizes

**Projeto de Álgebra Linear 2025-2026**  
IADE - Universidade Europeia  
Licenciatura em Engenharia Informática

---

## 📋 Descrição

Biblioteca de funções em C# para realizar operações com matrizes e suas aplicações. Este projeto aplica conhecimentos de **Álgebra Linear** e **Programação em C#**, implementando operações matriciais fundamentais e suas aplicações práticas.

---

## 🎯 Funcionalidades

### Funções Obrigatórias (9)

| Função | Descrição |
|--------|-----------|
| `Matrix_Read` | Leitura de matriz do teclado |
| `Matrix_Scalar_Mult` | Multiplicação por escalar |
| `Matrix_Add` | Soma de matrizes |
| `Matrix_Mult` | Multiplicação de matrizes |
| `Matrix_Inverse_2x2` | Inversa de matriz 2×2 |
| `Matrix_Determinant_3x3` | Determinante 3×3 (Laplace) |
| `Matrix_Transpose` | Transposta de matriz |
| `Matrix_IsDiagonal` | Verificar matriz diagonal |
| `Matrix_IsTriangular` | Verificar triangular superior |

### Funções Auxiliares (2)

- `Matrix_Print` - Impressão formatada de matrizes
- `Matrix_Determinant_2x2` - Determinante de matriz 2×2

### Funções Adicionais (6+)

| Função | Aplicação |
|--------|-----------|
| `Matrix_Trace` | Traço da matriz (sistemas dinâmicos) |
| `Matrix_Identity` | Matriz identidade (elemento neutro) |
| `Matrix_Power` | Potência de matriz (cadeias de Markov) |
| `Matrix_IsSymmetric` | Verificar simetria (formas quadráticas) |
| `Matrix_Subtract` | Subtração de matrizes |
| `Matrix_IsLowerTriangular` | Verificar triangular inferior (decomposição LU) |
| `Matrix_Norm_Frobenius` | Norma de Frobenius |

---

## 🚀 Como Usar

### Pré-requisitos

- .NET 6.0 ou superior
- Visual Studio 2022 / VS Code / Rider

### Compilação e Execução

#### Usando .NET CLI

```bash
# Clonar repositório
git clone https://github.com/seu-usuario/biblioteca-matrizes.git
cd biblioteca-matrizes/BibliotecaMatrizes

# Compilar
dotnet build

# Executar
dotnet run
```

#### Usando Visual Studio

1. Abrir ficheiro `BibliotecaMatrizes.csproj`
2. Pressionar `F5` ou clicar em "▶ Start"

#### Usando linha de comandos (Windows)

```cmd
csc /out:BibliotecaMatrizes.exe Program.cs MatrizOperacoes.cs MatrizOperacoesAdicionais.cs
BibliotecaMatrizes.exe
```

---

## 📁 Estrutura do Projeto

```
BibliotecaMatrizes/
│
├── Program.cs                      # Função Main com testes
├── MatrizOperacoes.cs              # Funções obrigatórias e auxiliares
├── MatrizOperacoesAdicionais.cs    # Funções adicionais
├── BibliotecaMatrizes.csproj       # Configuração do projeto
└── README.md                       # Este ficheiro
```

---

## 💻 Exemplos de Uso

### Exemplo 1: Multiplicação de Matrizes

```csharp
// Criar matrizes
double[,] A = { { 1, 2 }, { 3, 4 } };
double[,] B = { { 5, 6 }, { 7, 8 } };

// Multiplicar
double[,] C = MatrizOperacoes.Matrix_Mult(A, B);

// Imprimir resultado
MatrizOperacoes.Matrix_Print(C);
```

### Exemplo 2: Calcular Inversa

```csharp
// Criar matriz
double[,] matriz = { { 4, 7 }, { 2, 6 } };

// Calcular inversa
double[,] inversa = MatrizOperacoes.Matrix_Inverse_2x2(matriz);

// Imprimir
MatrizOperacoes.Matrix_Print(inversa);
```

### Exemplo 3: Verificar Propriedades

```csharp
double[,] M = { { 5, 0, 0 }, { 0, 3, 0 }, { 0, 0, 7 } };

bool diagonal = MatrizOperacoes.Matrix_IsDiagonal(M);          // true
bool triangular = MatrizOperacoes.Matrix_IsTriangular(M);       // true
bool simetrica = MatrizOperacoesAdicionais.Matrix_IsSymmetric(M); // true
```

---

## ✨ Características Técnicas

### Qualidade do Código

✅ **Comentários detalhados** em todas as linhas  
✅ **Tratamento de erros** robusto  
✅ **Validação de entradas** completa  
✅ **Tolerância numérica** para comparações de ponto flutuante (1e-10)  
✅ **Mensagens de erro** informativas  
✅ **Código modular** e reutilizável  

### Algoritmos Implementados

- **Multiplicação de matrizes**: O(n³) - algoritmo clássico
- **Determinante 3×3**: Expansão de Laplace pela primeira linha
- **Inversa 2×2**: Fórmula direta usando determinante
- **Potência de matriz**: Multiplicação sucessiva

---

## 🧪 Testes

O projeto inclui **15 testes** na função `Main()` que demonstram:

- ✅ Todas as funções obrigatórias
- ✅ Funções auxiliares
- ✅ Funções adicionais
- ✅ Casos extremos (matrizes singulares, dimensões incompatíveis)
- ✅ Verificação de propriedades

### Executar Testes

Simplesmente executar o programa - todos os testes são executados automaticamente.

---

## 📚 Aplicações Práticas

### Sistemas Lineares
```csharp
// Resolver Ax = b usando inversa
double[,] A = { { 2, 1 }, { 1, 3 } };
double[,] Ainv = MatrizOperacoes.Matrix_Inverse_2x2(A);
```

### Transformações Geométricas
```csharp
// Rotação, escala, translação usando matrizes
double[,] rotacao = { { Math.Cos(θ), -Math.Sin(θ) }, 
                      { Math.Sin(θ), Math.Cos(θ) } };
```

### Sistemas Dinâmicos
```csharp
// x(n) = A^n * x(0)
double[,] An = MatrizOperacoesAdicionais.Matrix_Power(A, n);
```

---

## 📖 Documentação Matemática

### Operações Básicas

**Soma de Matrizes**:  
`(A + B)[i,j] = A[i,j] + B[i,j]`

**Multiplicação de Matrizes**:  
`(AB)[i,j] = Σ A[i,k] * B[k,j]`

**Transposta**:  
`A^T[i,j] = A[j,i]`

### Determinante

**2×2**: `det(A) = ad - bc`

**3×3 (Laplace)**: Expansão pela primeira linha  
`det(A) = a₁₁C₁₁ - a₁₂C₁₂ + a₁₃C₁₃`

### Inversa 2×2

Para `A = [a b; c d]`:  
`A⁻¹ = (1/det(A)) * [d -b; -c a]`

### Propriedades

- **Diagonal**: `A[i,j] = 0` para `i ≠ j`
- **Triangular Superior**: `A[i,j] = 0` para `i > j`
- **Simétrica**: `A = A^T` ou `A[i,j] = A[j,i]`
- **Traço**: `tr(A) = Σ A[i,i]`
 

### Critérios

✅ Correção das implementações  
✅ Tratamento de erros  
✅ Documentação do código  
✅ Qualidade dos testes  
✅ Complexidade das funções adicionais  
✅ Boas práticas de programação  

---

## 👥 Equipa

**Turma**: [D03]  
**Grupo**: [4]

**Membros**:
- [Alfredo Bumba] - Nº [20221435]
- [Jose Luemba] - Nº [20251276]
- [Tiago Pascoal] - Nº [20252041]
- [Marcio Nhanga] - Nº [20252075]

---

## 📅 Entrega

**Data Limite**: 19 de dezembro de 2025  
**Prova de Autoria**: Primeira aula da última semana  

---

## 📧 Contactos

**Professores**:
- Rodolfo Bendoyro - [Rodolfo.Bendoyro@universidadeeuropeia.pt](mailto:Rodolfo.Bendoyro@universidadeeuropeia.pt)
- Francisco Barba - [francisco.barba@ext.universidadeeuropeia.pt](mailto:francisco.barba@ext.universidadeeuropeia.pt)

---

## 📝 Licença

Este projeto é desenvolvido para fins académicos no âmbito da UC de Álgebra Linear no IADE - Universidade Europeia.

---

## 🔗 Recursos

### Bibliografia
- Blyth, T.S., Robertson, E.F., *Basic Linear Algebra*, Springer, 2000
- Anton, H., Rorres, C., *Elementary Linear Algebra*, Wiley, 10ª Ed., 2010
