using System.ComponentModel.Design.Serialization;
using System.Media;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer 
        // to generate random numbers.
        private readonly Random randomizer = new();

        // These integer variables store the numbers 
        // for the addition problem. 
        private int addend1 = 0;
        private int addend2 = 0;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        private int minuend = 0;
        private int subtrahend = 0;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        private int multiplicand = 0;
        private int multiplier = 0;

        // These integer variables store the numbers 
        // for the division problem. 
        private int dividend = 0;
        private int divisor = 0;

        // This integer variable keeps track of the 
        // remaining time.
        private int timeLeft = 0;

        // Flag to trigger on_change events
        private bool _editing = true;

        // Hint sound effects
        // I found helpful resources for navigating to the sounds in my project 
        // at the following site
        //https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string rootDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        private readonly SoundPlayer goodSound = new(rootDir + @"\Sounds\rightAnswer.wav");
        private readonly SoundPlayer badSound = new(rootDir + @"\Sounds\wrongAnswer.wav");

        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timeLabel.BackColor = Color.Green;
            timer1.Start();
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void checkAnswers(object sender, EventArgs e)
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
            {
                // The user got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
                submitButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("You got something wrong. Keep trying!");
            }
        }

        public Form1()
        {
            InitializeComponent();
            dateLabel.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _editing = false;
            StartTheQuiz();
            startButton.Enabled = false;
            submitButton.Enabled = true;
            _editing = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //_editing = false;
            if (timeLeft > 0)
            {
                // If CheckTheAnswer() returns false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                submitButton.Enabled = false;
            }
            //_editing = true;
        }

        private void play_answer_sound(bool isRight)
        {
            if (isRight) { goodSound.Play(); }
            else { badSound.Play(); }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (_editing)
            {
                bool isRight = (addend1 + addend2 == sum.Value);
                play_answer_sound(isRight);
                if (!isRight)
                {
                    sum.Value = 0;
                    answer_Enter(sum, e);
                }
            }
        }
        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (_editing)
            {
                bool isRight = (minuend - subtrahend == difference.Value);
                play_answer_sound(isRight);
                if (!isRight)
                {
                    difference.Value = 0;
                    answer_Enter(sum, e);
                }
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            if (_editing)
            {
                bool isRight = (multiplicand * multiplier == product.Value);
                play_answer_sound(isRight);
                if (!isRight)
                {
                    product.Value = 0;
                    answer_Enter(sum, e);
                }
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (_editing)
            {
                bool isRight = (dividend / divisor == quotient.Value);
                play_answer_sound(isRight);
                if (!isRight)
                {
                    quotient.Value = 0;
                    answer_Enter(sum, e);
                }
            }
        }
    }
}