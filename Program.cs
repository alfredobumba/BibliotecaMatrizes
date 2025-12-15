using System;

namespace BibliotecaMatrizes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurar encoding para suportar caracteres portugueses
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Título principal do programa
            Console.WriteLine("===============================================");
            Console.WriteLine("   BIBLIOTECA DE OPERAÇÕES COM MATRIZES");
            Console.WriteLine("   IADE - Álgebra Linear 2025-2026");
            Console.WriteLine("===============================================\n");

            // ==================== TESTE 1: Leitura de Matriz ====================
            Console.WriteLine("--- TESTE 1: Leitura de Matriz ---");
            Console.WriteLine("Digite uma matriz 2x2:");
            
            // Chamar função para ler matriz do teclado
            double[,] matriz1 = MatrizOperacoes.Matrix_Read(2, 2);
            
            // Exibir matriz lida
            Console.WriteLine("Matriz lida:");
            MatrizOperacoes.Matrix_Print(matriz1);

            // ==================== TESTE 2: Multiplicação por Escalar ====================
            Console.WriteLine("\n--- TESTE 2: Multiplicação por Escalar ---");
            
            // Criar matriz de teste
            double[,] matrizA = { { 1, 2 }, { 3, 4 } };
            Console.WriteLine("Matriz original:");
            MatrizOperacoes.Matrix_Print(matrizA);
            
            // Definir escalar para multiplicação
            double escalar = 3;
            
            // Multiplicar matriz por escalar
            double[,] resultadoEscalar = MatrizOperacoes.Matrix_Scalar_Mult(matrizA, escalar);
            Console.WriteLine($"Matriz multiplicada por {escalar}:");
            MatrizOperacoes.Matrix_Print(resultadoEscalar);

            // ==================== TESTE 3: Soma de Matrizes ====================
            Console.WriteLine("\n--- TESTE 3: Soma de Matrizes ---");
            
            // Criar segunda matriz
            double[,] matrizB = { { 5, 6 }, { 7, 8 } };
            
            // Exibir matrizes a somar
            Console.WriteLine("Matriz A:");
            MatrizOperacoes.Matrix_Print(matrizA);
            Console.WriteLine("Matriz B:");
            MatrizOperacoes.Matrix_Print(matrizB);
            
            // Somar as matrizes
            double[,] resultadoSoma = MatrizOperacoes.Matrix_Add(matrizA, matrizB);
            Console.WriteLine("Soma A + B:");
            MatrizOperacoes.Matrix_Print(resultadoSoma);

            // ==================== TESTE 4: Multiplicação de Matrizes ====================
            Console.WriteLine("\n--- TESTE 4: Multiplicação de Matrizes ---");
            
            // Criar matrizes compatíveis para multiplicação
            double[,] matrizC = { { 1, 2, 3 }, { 4, 5, 6 } }; // 2x3
            double[,] matrizD = { { 7, 8 }, { 9, 10 }, { 11, 12 } }; // 3x2
            
            // Exibir matrizes
            Console.WriteLine("Matriz C (2x3):");
            MatrizOperacoes.Matrix_Print(matrizC);
            Console.WriteLine("Matriz D (3x2):");
            MatrizOperacoes.Matrix_Print(matrizD);
            
            // Multiplicar matrizes
            double[,] resultadoMult = MatrizOperacoes.Matrix_Mult(matrizC, matrizD);
            Console.WriteLine("Produto C × D:");
            MatrizOperacoes.Matrix_Print(resultadoMult);

            // ==================== TESTE 5: Inversa de Matriz 2x2 ====================
            Console.WriteLine("\n--- TESTE 5: Inversa de Matriz 2x2 ---");
            
            // Criar matriz 2x2 invertível
            double[,] matrizE = { { 4, 7 }, { 2, 6 } };
            Console.WriteLine("Matriz original:");
            MatrizOperacoes.Matrix_Print(matrizE);
            
            // Calcular inversa
            double[,] inversa = MatrizOperacoes.Matrix_Inverse_2x2(matrizE);
            
            // Verificar se inversa foi calculada
            if (inversa != null)
            {
                Console.WriteLine("Matriz inversa:");
                MatrizOperacoes.Matrix_Print(inversa);
                
                // Verificar multiplicação A * A^(-1) = I
                Console.WriteLine("Verificação: A × A^(-1) deve ser identidade:");
                double[,] verificacao = MatrizOperacoes.Matrix_Mult(matrizE, inversa);
                MatrizOperacoes.Matrix_Print(verificacao);
            }

            // ==================== TESTE 6: Determinante 3x3 ====================
            Console.WriteLine("\n--- TESTE 6: Determinante de Matriz 3x3 ---");
            
            // Criar matriz 3x3
            double[,] matrizF = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 10 } };
            Console.WriteLine("Matriz 3x3:");
            MatrizOperacoes.Matrix_Print(matrizF);
            
            // Calcular determinante
            double det = MatrizOperacoes.Matrix_Determinant_3x3(matrizF);
            Console.WriteLine($"Determinante: {det}");

            // ==================== TESTE 7: Transposta ====================
            Console.WriteLine("\n--- TESTE 7: Transposta de Matriz ---");
            
            // Criar matriz retangular
            double[,] matrizG = { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine("Matriz original (2x3):");
            MatrizOperacoes.Matrix_Print(matrizG);
            
            // Calcular transposta
            double[,] transposta = MatrizOperacoes.Matrix_Transpose(matrizG);
            Console.WriteLine("Matriz transposta (3x2):");
            MatrizOperacoes.Matrix_Print(transposta);

            // ==================== TESTE 8: Verificar Matriz Diagonal ====================
            Console.WriteLine("\n--- TESTE 8: Verificar Matriz Diagonal ---");
            
            // Criar matriz diagonal
            double[,] matrizDiag = { { 5, 0, 0 }, { 0, 3, 0 }, { 0, 0, 7 } };
            Console.WriteLine("Matriz 1:");
            MatrizOperacoes.Matrix_Print(matrizDiag);
            Console.WriteLine($"É diagonal? {MatrizOperacoes.Matrix_IsDiagonal(matrizDiag)}");
            
            // Criar matriz não diagonal
            double[,] matrizNaoDiag = { { 5, 1, 0 }, { 0, 3, 0 }, { 0, 0, 7 } };
            Console.WriteLine("\nMatriz 2:");
            MatrizOperacoes.Matrix_Print(matrizNaoDiag);
            Console.WriteLine($"É diagonal? {MatrizOperacoes.Matrix_IsDiagonal(matrizNaoDiag)}");

            // ==================== TESTE 9: Verificar Matriz Triangular Superior ====================
            Console.WriteLine("\n--- TESTE 9: Verificar Matriz Triangular Superior ---");
            
            // Criar matriz triangular superior
            double[,] matrizTri = { { 1, 2, 3 }, { 0, 4, 5 }, { 0, 0, 6 } };
            Console.WriteLine("Matriz 1:");
            MatrizOperacoes.Matrix_Print(matrizTri);
            Console.WriteLine($"É triangular superior? {MatrizOperacoes.Matrix_IsTriangular(matrizTri)}");
            
            // Criar matriz não triangular
            double[,] matrizNaoTri = { { 1, 2, 3 }, { 1, 4, 5 }, { 0, 0, 6 } };
            Console.WriteLine("\nMatriz 2:");
            MatrizOperacoes.Matrix_Print(matrizNaoTri);
            Console.WriteLine($"É triangular superior? {MatrizOperacoes.Matrix_IsTriangular(matrizNaoTri)}");

            // ==================== FUNÇÕES ADICIONAIS ====================
            Console.WriteLine("\n\n===============================================");
            Console.WriteLine("        FUNÇÕES ADICIONAIS");
            Console.WriteLine("===============================================\n");

            // ==================== TESTE 10: Traço da Matriz ====================
            Console.WriteLine("--- TESTE 10: Traço da Matriz ---");
            
            // Criar matriz quadrada
            double[,] matrizH = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Matriz:");
            MatrizOperacoes.Matrix_Print(matrizH);
            
            // Calcular traço
            double traco = MatrizOperacoesAdicionais.Matrix_Trace(matrizH);
            Console.WriteLine($"Traço (soma da diagonal): {traco}");

            // ==================== TESTE 11: Matriz Identidade ====================
            Console.WriteLine("\n--- TESTE 11: Matriz Identidade ---");
            
            // Criar matriz identidade 4x4
            double[,] identidade = MatrizOperacoesAdicionais.Matrix_Identity(4);
            Console.WriteLine("Matriz identidade 4x4:");
            MatrizOperacoes.Matrix_Print(identidade);

            // ==================== TESTE 12: Potência de Matriz ====================
            Console.WriteLine("\n--- TESTE 12: Potência de Matriz ---");
            
            // Criar matriz base
            double[,] matrizI = { { 1, 2 }, { 3, 4 } };
            Console.WriteLine("Matriz original:");
            MatrizOperacoes.Matrix_Print(matrizI);
            
            // Calcular potência
            double[,] potencia = MatrizOperacoesAdicionais.Matrix_Power(matrizI, 3);
            Console.WriteLine("Matriz elevada à potência 3:");
            MatrizOperacoes.Matrix_Print(potencia);

            // ==================== TESTE 13: Verificar Simetria ====================
            Console.WriteLine("\n--- TESTE 13: Verificar Matriz Simétrica ---");
            
            // Criar matriz simétrica
            double[,] matrizSim = { { 1, 2, 3 }, { 2, 4, 5 }, { 3, 5, 6 } };
            Console.WriteLine("Matriz:");
            MatrizOperacoes.Matrix_Print(matrizSim);
            Console.WriteLine($"É simétrica? {MatrizOperacoesAdicionais.Matrix_IsSymmetric(matrizSim)}");

            // ==================== TESTE 14: Subtração de Matrizes ====================
            Console.WriteLine("\n--- TESTE 14: Subtração de Matrizes ---");
            
            // Usar matrizes já criadas
            Console.WriteLine("Matriz A:");
            MatrizOperacoes.Matrix_Print(matrizA);
            Console.WriteLine("Matriz B:");
            MatrizOperacoes.Matrix_Print(matrizB);
            
            // Subtrair matrizes
            double[,] resultadoSub = MatrizOperacoesAdicionais.Matrix_Subtract(matrizA, matrizB);
            Console.WriteLine("Diferença A - B:");
            MatrizOperacoes.Matrix_Print(resultadoSub);

            // ==================== TESTE 15: Triangular Inferior ====================
            Console.WriteLine("\n--- TESTE 15: Verificar Matriz Triangular Inferior ---");
            
            // Criar matriz triangular inferior
            double[,] matrizTriInf = { { 1, 0, 0 }, { 2, 3, 0 }, { 4, 5, 6 } };
            Console.WriteLine("Matriz:");
            MatrizOperacoes.Matrix_Print(matrizTriInf);
            Console.WriteLine($"É triangular inferior? {MatrizOperacoesAdicionais.Matrix_IsLowerTriangular(matrizTriInf)}");

            // Mensagem final
            Console.WriteLine("\n===============================================");
            Console.WriteLine("        FIM DOS TESTES");
            Console.WriteLine("===============================================");
            
            // Aguardar tecla para fechar
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}