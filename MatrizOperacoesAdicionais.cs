using System;

namespace BibliotecaMatrizes
{
    // Classe com funções adicionais de operações com matrizes
    public static class MatrizOperacoesAdicionais
    {
        // ==================== FUNÇÕES ADICIONAIS ====================

        // Função: Matrix_Trace
        // Calcula o traço da matriz (soma dos elementos da diagonal principal)
        // O traço tem propriedades importantes: tr(A+B) = tr(A)+tr(B), tr(AB) = tr(BA)
        // Parâmetros: matriz - matriz quadrada
        // Retorna: valor do traço ou 0 em caso de erro
        public static double Matrix_Trace(double[,] matriz)
        {
            try
            {
                // Verificar se matriz não é nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula!");
                    return 0;
                }

                // Obter dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Matriz deve ser quadrada para calcular traço
                if (linhas != colunas)
                {
                    Console.WriteLine("ERRO: Matriz deve ser quadrada para calcular o traço!");
                    return 0;
                }

                // Inicializar acumulador do traço
                double traco = 0;
                
                // Percorrer diagonal principal (i == j)
                for (int i = 0; i < linhas; i++)
                {
                    // Somar elemento da diagonal
                    traco += matriz[i, i];
                }

                // Retornar traço calculado
                return traco;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao calcular traço: {ex.Message}");
                return 0;
            }
        }

        // Função: Matrix_Identity
        // Cria uma matriz identidade de ordem n
        // Matriz identidade tem 1 na diagonal e 0 nos outros elementos
        // É o elemento neutro da multiplicação: A * I = I * A = A
        // Parâmetros: n - ordem da matriz identidade
        // Retorna: matriz identidade n×n ou null em caso de erro
        public static double[,] Matrix_Identity(int n)
        {
            try
            {
                // Verificar se ordem é válida
                if (n <= 0)
                {
                    Console.WriteLine("ERRO: Ordem da matriz deve ser positiva!");
                    return null;
                }

                // Criar matriz quadrada n×n
                double[,] identidade = new double[n, n];

                // Percorrer todos os elementos
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // Se na diagonal (i == j), colocar 1
                        // Caso contrário, colocar 0
                        identidade[i, j] = (i == j) ? 1 : 0;
                    }
                }

                // Retornar matriz identidade
                return identidade;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao criar matriz identidade: {ex.Message}");
                return null;
            }
        }

        // Função: Matrix_Power
        // Calcula a potência de uma matriz quadrada
        // A^n = A * A * ... * A (n vezes)
        // Útil em sistemas dinâmicos: x(n) = A^n * x(0)
        // Parâmetros: matriz - matriz base (quadrada), expoente - potência (≥ 0)
        // Retorna: matriz^expoente ou null em caso de erro
        public static double[,] Matrix_Power(double[,] matriz, int expoente)
        {
            try
            {
                // Verificar se matriz não é nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula!");
                    return null;
                }

                // Obter dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Matriz deve ser quadrada para calcular potência
                if (linhas != colunas)
                {
                    Console.WriteLine("ERRO: Matriz deve ser quadrada para calcular potência!");
                    return null;
                }

                // Expoente deve ser não-negativo
                if (expoente < 0)
                {
                    Console.WriteLine("ERRO: Expoente deve ser não negativo!");
                    return null;
                }

                // Caso especial: A^0 = I (identidade)
                if (expoente == 0)
                {
                    return Matrix_Identity(linhas);
                }

                // Iniciar com cópia da matriz original
                // Clone() cria cópia superficial, cast para double[,]
                double[,] resultado = (double[,])matriz.Clone();

                // Multiplicar matriz por si mesma (expoente - 1) vezes
                for (int i = 1; i < expoente; i++)
                {
                    // resultado = resultado * matriz
                    resultado = MatrizOperacoes.Matrix_Mult(resultado, matriz);
                }

                // Retornar resultado da potência
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao calcular potência de matriz: {ex.Message}");
                return null;
            }
        }

        // Função: Matrix_IsSymmetric
        // Verifica se uma matriz é simétrica (A = A^T)
        // Matriz simétrica: elemento [i,j] = elemento [j,i]
        // Matrizes simétricas têm autovalores reais e autovetores ortogonais
        // Parâmetros: matriz - matriz a verificar
        // Retorna: true se simétrica, false caso contrário
        public static bool Matrix_IsSymmetric(double[,] matriz)
        {
            try
            {
                // Verificar se matriz não é nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula!");
                    return false;
                }

                // Obter dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Matriz simétrica deve ser quadrada
                if (linhas != colunas)
                {
                    // Se não é quadrada, não pode ser simétrica
                    return false;
                }

                // Verificar simetria comparando elementos
                // Só precisa verificar triângulo superior (ou inferior)
                for (int i = 0; i < linhas; i++)
                {
                    // j < i garante que só verifica abaixo da diagonal
                    for (int j = 0; j < i; j++)
                    {
                        // Comparar elemento [i,j] com [j,i]
                        // Usar tolerância para evitar erros de precisão numérica
                        if (Math.Abs(matriz[i, j] - matriz[j, i]) > 1e-10)
                        {
                            // Encontrou assimetria
                            return false;
                        }
                    }
                }

                // Todos elementos simétricos
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao verificar simetria: {ex.Message}");
                return false;
            }
        }

        // Função: Matrix_Subtract
        // Subtrai duas matrizes elemento a elemento (A - B)
        // Parâmetros: matrizA - matriz minuendo, matrizB - matriz subtraendo
        // Retorna: matriz diferença ou null se dimensões incompatíveis
        public static double[,] Matrix_Subtract(double[,] matrizA, double[,] matrizB)
        {
            try
            {
                // Verificar se ambas matrizes não são nulas
                if (matrizA == null || matrizB == null)
                {
                    Console.WriteLine("ERRO: As matrizes não podem ser nulas!");
                    return null;
                }

                // Obter dimensões de A
                int linhasA = matrizA.GetLength(0);
                int colunasA = matrizA.GetLength(1);
                
                // Obter dimensões de B
                int linhasB = matrizB.GetLength(0);
                int colunasB = matrizB.GetLength(1);

                // Verificar compatibilidade de dimensões
                if (linhasA != linhasB || colunasA != colunasB)
                {
                    Console.WriteLine("ERRO: As matrizes devem ter as mesmas dimensões!");
                    return null;
                }

                // Criar matriz para resultado
                double[,] resultado = new double[linhasA, colunasA];

                // Percorrer todos os elementos
                for (int i = 0; i < linhasA; i++)
                {
                    for (int j = 0; j < colunasA; j++)
                    {
                        // Subtrair elementos correspondentes
                        resultado[i, j] = matrizA[i, j] - matrizB[i, j];
                    }
                }

                // Retornar matriz diferença
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO na subtração de matrizes: {ex.Message}");
                return null;
            }
        }

        // Função: Matrix_IsLowerTriangular
        // Verifica se matriz é triangular inferior
        // (todos elementos acima da diagonal são zero)
        // Útil em decomposição LU e resolução de sistemas triangulares
        // Parâmetros: matriz - matriz a verificar
        // Retorna: true se triangular inferior, false caso contrário
        public static bool Matrix_IsLowerTriangular(double[,] matriz)
        {
            try
            {
                // Verificar se matriz não é nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula!");
                    return false;
                }

                // Obter dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Matriz triangular deve ser quadrada
                if (linhas != colunas)
                {
                    Console.WriteLine("ERRO: Matriz deve ser quadrada!");
                    return false;
                }

                // Percorrer elementos acima da diagonal
                for (int i = 0; i < linhas; i++)
                {
                    // j > i significa elementos acima da diagonal
                    for (int j = i + 1; j < colunas; j++)
                    {
                        // Verificar se elemento é diferente de zero
                        if (Math.Abs(matriz[i, j]) > 1e-10)
                        {
                            // Encontrou elemento não-zero acima da diagonal
                            return false;
                        }
                    }
                }

                // Todos elementos acima da diagonal são zero
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao verificar matriz triangular inferior: {ex.Message}");
                return false;
            }
        }

        // Função adicional: Matrix_Norm_Frobenius
        // Calcula a norma de Frobenius de uma matriz
        // ||A||_F = sqrt(sum(a_ij^2))
        // É a raiz quadrada da soma dos quadrados de todos os elementos
        // Parâmetros: matriz - matriz para calcular norma
        // Retorna: valor da norma ou 0 em caso de erro
        public static double Matrix_Norm_Frobenius(double[,] matriz)
        {
            try
            {
                // Verificar se matriz não é nula
                if (matriz == null)
                {
                    Console.WriteLine("ERRO: Matriz não pode ser nula!");
                    return 0;
                }

                // Obter dimensões
                int linhas = matriz.GetLength(0);
                int colunas = matriz.GetLength(1);

                // Inicializar soma dos quadrados
                double somaQuadrados = 0;

                // Percorrer todos os elementos
                for (int i = 0; i < linhas; i++)
                {
                    for (int j = 0; j < colunas; j++)
                    {
                        // Adicionar quadrado do elemento
                        somaQuadrados += matriz[i, j] * matriz[i, j];
                    }
                }

                // Retornar raiz quadrada da soma
                return Math.Sqrt(somaQuadrados);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao calcular norma: {ex.Message}");
                return 0;
            }
        }
    }
}