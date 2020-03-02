Public Class Form1
    '########## Variabler vi skal bruke i flere deler av spillet #############

    'Totalsummen spilleren har til enhver tid
    Public playerTotal As Integer = 0

    'Totalsummen dealeren har til enhver tid
    Public computerTotal As Integer = 0

    'Teller for å se hvor mange kort som har blitt trukket
    Public teller As Integer = 1

    'Array for å velge hvilken verdi kortet skal ha
    Public array = {2, 3, 10, 4, 5, 10, 6, 7, 10, 8, 9, 10, 11, 2, 3, 10, 4, 5, 10, 6, 7, 10, 8, 9, 10, 11, 2, 3, 10, 4, 5, 10, 6, 7, 10, 8, 9, 10, 11, 2, 3, 10, 4, 5, 10, 6, 7, 10, 8, 9, 10, 11}

    'Array for å velge hvilket kort som kal representere verdien
    Public ImgArray = {"c2", "c3", "cj", "c4", "c5", "ck", "c6", "c7", "cq", "c8", "c9", "c10", "c1", "d2", "d3", "dj", "d4", "d5", "dk", "d6", "d7", "dq", "d8", "d9", "d10", "d1", "h2", "h3", "hj", "h4", "h5", "hk", "h6", "h7", "hq", "h8", "h9", "h10", "h1", "s2", "s3", "sj", "s4", "s5", "sk", "s6", "s7", "sq", "s8", "s9", "s10", "s1"}

    'Tilfeldig verdi for å trekke ut kort og kortets verdi
    Dim randomValue As Integer = 0

    'Spillerkort
    Dim playerCard1 As Integer = 0
    Dim playerCard2 As Integer = 0
    Dim playerCard3 As Integer = 0
    Dim playerCard4 As Integer = 0
    Dim playerCard5 As Integer = 0

    'Dealers Kort
    Dim dealerKort1 As Integer = 0
    Dim dealerKort2 As Integer = 0
    Dim dealerKort3 As Integer = 0
    Dim dealerKort4 As Integer = 0
    Dim dealerKort5 As Integer = 0

    'Deklarerer navn på hvilke kort som skal vises når spilleren trykker stå
    Dim dealerKortShow1 As String = ""
    Dim dealerKortShow2 As String = ""
    Dim dealerKortShow3 As String = ""
    Dim dealerKortShow4 As String = ""
    Dim dealerKortShow5 As String = ""

    Dim essTellerSpiller As Integer = 0
    Dim essTellerDealer As Integer = 0
    '##################### Når Spillet Starter ##########################
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        startSpillKnapp.Visible = True

    End Sub
    Private Sub startSpillKnapp_Click(sender As Object, e As EventArgs) Handles startSpillKnapp.Click

        'Fjerner startspill knappen
        startSpillKnapp.Visible = False

        'Skuler avsluttningsbilde
        PictureBox14.Visible = False
        spillIgjen.Visible = False
        lblWinLose.Visible = False
        'Gjør det mulig å tilfeldiggjøre valg av tall
        Randomize()

        'Spillerkort Synlige/ikke synlige
        PictureBox1.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False

        'Dealerkort Synlige/ikke synlige
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False

        'Trekke de to første kortene for spilleren
        randomValue = Convert.ToInt32(51 * Rnd())
        playerCard1 = array.GetValue(randomValue)
        PictureBox1.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
        If playerCard1 = 11 Then
            essTellerSpiller = essTellerSpiller + 1
        End If
        randomValue = Convert.ToInt32(51 * Rnd())
        playerCard2 = array.GetValue(randomValue)
        PictureBox2.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
        If playerCard2 = 11 Then
            essTellerSpiller = essTellerSpiller + 1
        End If
        If playerTotal > 21 Then
            playerTotal = playerTotal - (10 * essTellerSpiller)
        End If

        'Regner ut scoren til spilleren
        playerTotal = Val(playerCard1) + Val(playerCard2)

        'Trekke kort for dealeren og spesifiserer hvilket kort som skal vises senere
        randomValue = Convert.ToInt32(51 * Rnd())
        dealerKort1 = array.GetValue(randomValue)
        dealerKortShow1 = ImgArray.GetValue(randomValue)
        If dealerKort1 = 11 Then
            essTellerDealer = essTellerDealer + 1
        End If
        randomValue = Convert.ToInt32(51 * Rnd())
        dealerKort2 = array.GetValue(randomValue)
        dealerKortShow2 = ImgArray.GetValue(randomValue)
        If dealerKort2 = 11 Then
            essTellerDealer = essTellerDealer + 1
        End If
        If computerTotal > 21 Then
            computerTotal = computerTotal - (10 * essTellerDealer)
        End If

        'Summere opp total score for dealer
        computerTotal = Val(dealerKort1) + Val(dealerKort2)

        'Sjekker om dealer skal trekke flere kort, regel i blackjack er at
        'dealer alltid skal trekke om ikke totalen er 17 eller mer.
        If computerTotal < 17 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            dealerKort3 = array.GetValue(randomValue)
            dealerKortShow3 = ImgArray.GetValue(randomValue)
            If dealerKort3 = 11 Then
                essTellerDealer = essTellerDealer + 1
            End If
            If computerTotal > 21 Then
                computerTotal = computerTotal - (10 * essTellerDealer)
            End If
        End If

        computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3)

        If computerTotal < 17 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            dealerKort4 = array.GetValue(randomValue)
            dealerKortShow4 = ImgArray.GetValue(randomValue)
            If dealerKort4 = 11 Then
                essTellerDealer = essTellerDealer + 1
            End If
            If computerTotal > 21 Then
                computerTotal = computerTotal - (10 * essTellerDealer)
            End If
        End If

        computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3) + Val(dealerKort4)

        If computerTotal < 17 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            dealerKort5 = array.GetValue(randomValue)
            dealerKortShow5 = ImgArray.GetValue(randomValue)
            If dealerKort5 = 11 Then
                essTellerDealer = essTellerDealer + 1
            End If
            If computerTotal > 21 Then
                computerTotal = computerTotal - (10 * essTellerDealer)
            End If
        End If

        If dealerKort3 = Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2)
        End If
        If dealerKort4 = Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3)
        End If
        If dealerKort5 = Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3) + Val(dealerKort4)
        End If
        If dealerKort5 <> Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3) + Val(dealerKort4) + Val(dealerKort5)
        End If

        'Viser antall poeng kortene til spilleren er verdt så langt
        lblPlayerScore.Text = "Dine Poeng: " & playerTotal

        'Bestemmer bakgrunnen på spillet
        Me.BackColor = Color.Green

    End Sub
    '######################  NYTT KORT ###########################################
    Private Sub nyttKort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nyttKort.Click

        'Gjør det mulig å trekke et tilfeldig tall
        Randomize()

        'Teller antall kort trekt
        teller = teller + 1

        'Velger tilfeldige kort
        If teller = 2 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            playerCard3 = array.GetValue(randomValue)
            PictureBox3.Visible = True
            PictureBox3.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
            playerTotal = Val(playerCard1) + Val(playerCard2) + Val(playerCard3)
            If playerCard3 = 11 Then
                essTellerSpiller = essTellerSpiller + 1
            End If
            If playerTotal > 21 Then
                playerTotal = playerTotal - (10 * essTellerSpiller)
            End If
        ElseIf teller = 3 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            playerCard4 = array.GetValue(randomValue)
            PictureBox4.Visible = True
            PictureBox4.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
            playerTotal = Val(playerCard1) + Val(playerCard2) + Val(playerCard3) + Val(playerCard4)
            If playerCard4 = 11 Then
                essTellerSpiller = essTellerSpiller + 1
            End If
            If playerTotal > 21 Then
                playerTotal = playerTotal - (10 * essTellerSpiller)
            End If
        ElseIf teller = 4 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            playerCard5 = array.GetValue(randomValue)
            PictureBox5.Visible = True
            PictureBox5.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
            playerTotal = Val(playerCard1) + Val(playerCard2) + Val(playerCard3) + Val(playerCard4) + Val(playerCard5)
            If playerCard5 = 11 Then
                essTellerSpiller = essTellerSpiller + 1
            End If
            If playerTotal > 21 Then
                playerTotal = playerTotal - (10 * essTellerSpiller)
            End If
        ElseIf teller >= 4 Then
            nyttKort.Enabled = False
            'Presenterer en boks som sier at brukeren har nådd grensen kort han kan trekke
            MsgBox(MsgBoxStyle.OkOnly, MsgBoxStyle.Critical, "Du kan ikke trekke flere kort, og må nå stå")
        End If

        'Presenterer spillerens poengsum
        lblPlayerScore.Text = "Dine Poeng: " & playerTotal

        'Avslutter runden automatisk om poengsummen overgår 21, og forteller at spilleren har tapt.
        If playerTotal > 21 Then
            lblWinLose.Text = ("Du tapte!")
            PictureBox14.Image = My.Resources.Glad_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
            nyttKort.BackColor = Color.Gray
            stå.BackColor = Color.Gray
        End If
    End Sub

    '######################  STÅ - Presenter Resultat #################################
    Private Sub stå_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stå.Click

        'Legger inn hvilke kort som skal vises av dealerens kort
        PictureBox6.Image = My.Resources.ResourceManager.GetObject(dealerKortShow1)
        PictureBox7.Image = My.Resources.ResourceManager.GetObject(dealerKortShow2)
        PictureBox8.Image = My.Resources.ResourceManager.GetObject(dealerKortShow3)
        PictureBox9.Image = My.Resources.ResourceManager.GetObject(dealerKortShow4)
        PictureBox10.Image = My.Resources.ResourceManager.GetObject(dealerKortShow5)

        'Viser Dealerens kort
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = True
        PictureBox9.Visible = True
        PictureBox10.Visible = True

        'Viser bare kortene som dealeren har bedt om
        If dealerKort3 = Nothing Then
            PictureBox7.Visible = True
        End If
        If dealerKort4 = Nothing Then
            PictureBox8.Visible = True
        End If
        If dealerKort5 = Nothing Then
            PictureBox9.Visible = True
        End If

        'Slår av knappene "NYTT KORT" og "STÅ", presenterer dette også visuelt
        nyttKort.Enabled = False
        stå.Enabled = False
        nyttKort.BackColor = Color.Gray
        stå.BackColor = Color.Gray

        'Presenterer scoren til spiller og dealer
        lblPlayerScore.Text = "Dine Poeng: " & playerTotal
        lblComputerScore.Text = "Dealers Poeng: " & computerTotal

        'Informerer spilleren om hvem som vant runden, eller om det ble uavgjort
        If playerTotal <= 21 And playerTotal > computerTotal Then
            lblWinLose.Text = ("Du vant!")
            PictureBox14.Image = My.Resources.Sinna_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf computerTotal > 21 And playerTotal <= 21 Then
            lblWinLose.Text = ("Du vant!")
            PictureBox14.Image = My.Resources.forvirret_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf playerTotal = 21 And computerTotal <> 21 Then
            lblWinLose.Text = ("Du vant!")
            PictureBox14.Image = My.Resources.Sinna_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf computerTotal < 21 And computerTotal > playerTotal Then
            lblWinLose.Text = ("Du tapte!")
            PictureBox14.Image = My.Resources.Glad_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf playerTotal > 21 And computerTotal < 21 Then
            lblWinLose.Text = ("Du tapte!")
            PictureBox14.Image = My.Resources.Glad_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf computerTotal = 21 And playerTotal <> 21 Then
            lblWinLose.Text = ("Du tapte!")
            PictureBox14.Image = My.Resources.Glad_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf computerTotal = playerTotal Then
            lblWinLose.Text = ("Uavgjort!")
            PictureBox14.Image = My.Resources.sinna_cowboy2
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        ElseIf playerTotal > 21 And computerTotal > 21 Then
            lblWinLose.Text = ("Uavgjort!")
            PictureBox14.Image = My.Resources.forvirret_cowboy
            PictureBox14.Visible = True
            spillIgjen.Visible = True
            lblWinLose.Visible = True
        End If
    End Sub

    '######################### Spill IGJEN ######################################
    Private Sub spillIgjen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spillIgjen.Click

        'Skjul avsluttningsbilde/beskjed
        PictureBox14.Visible = False
        spillIgjen.Visible = False
        lblWinLose.Visible = False

        'Tilbakestill bilde av Cowboy
        PictureBox13.Image = My.Resources.klar_for_kamp_cowboy

        'Skjuler kort som ikke skal vises ennå
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False


        'Nullstiller kortverdier for dealeren
        dealerKort1 = 0
        dealerKort2 = 0
        dealerKort3 = 0
        dealerKort4 = 0
        dealerKort5 = 0
        lblComputerScore.Text = "Dealers poeng: "

        'Nullstiller kortverdeier for spilleren
        playerCard1 = 0
        playerCard2 = 0
        playerCard3 = 0
        playerCard4 = 0
        playerCard5 = 0
        lblPlayerScore.Text = "Dine Poeng: "

        'Nulstiller valg av kort dealer
        dealerKortShow1 = ""
        dealerKortShow2 = ""
        dealerKortShow3 = ""
        dealerKortShow4 = ""
        dealerKortShow5 = ""

        'Nullstiller resultatmeldingen
        lblWinLose.Text = ""

        'Nulstiller tellere
        teller = 1
        essTellerSpiller = 0
        essTellerDealer = 0

        'Nulstiller scoren for dealer og spiller
        playerTotal = 0
        computerTotal = 0

        'Aktiverer knapper, også visuelt
        nyttKort.Enabled = True
        stå.Enabled = True
        nyttKort.BackColor = Color.LightGray
        stå.BackColor = Color.LightGray

        'Gjør det mulig å tilfeldiggjøre valg av tall
        Randomize()

        'Spillerkort Synlige/ikke synlige
        PictureBox1.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False

        'Dealerkort Synlige/ikke synlige
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False

        'Trekke de to første kortene for spilleren
        randomValue = Convert.ToInt32(51 * Rnd())
        playerCard1 = array.GetValue(randomValue)
        PictureBox1.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
        If playerCard1 = 11 Then
            essTellerSpiller = essTellerSpiller + 1
        End If
        randomValue = Convert.ToInt32(51 * Rnd())
        playerCard2 = array.GetValue(randomValue)
        PictureBox2.Image = My.Resources.ResourceManager.GetObject(ImgArray.GetValue(randomValue))
        If playerCard2 = 11 Then
            essTellerSpiller = essTellerSpiller + 1
        End If

        'Regner ut scoren til spilleren
        playerTotal = Val(playerCard1) + Val(playerCard2)

        'Trekke kort for dealeren og spesifiserer hvilket kort som skal vises senere
        randomValue = Convert.ToInt32(51 * Rnd())
        dealerKort1 = array.GetValue(randomValue)
        dealerKortShow1 = ImgArray.GetValue(randomValue)
        randomValue = Convert.ToInt32(51 * Rnd())
        dealerKort2 = array.GetValue(randomValue)
        dealerKortShow2 = ImgArray.GetValue(randomValue)

        'Summere opp total score for dealer
        computerTotal = Val(dealerKort1) + Val(dealerKort2)

        'Sjekker om dealer skal trekke flere kort, regel i blackjack er at
        'dealer alltid skal trekke om ikke totalen er 17 eller mer.
        If computerTotal < 17 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            dealerKort3 = array.GetValue(randomValue)
            dealerKortShow3 = ImgArray.GetValue(randomValue)
        End If

        computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3)

        If computerTotal < 17 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            dealerKort4 = array.GetValue(randomValue)
            dealerKortShow4 = ImgArray.GetValue(randomValue)
        End If

        computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3) + Val(dealerKort4)

        If computerTotal < 17 Then
            randomValue = Convert.ToInt32(51 * Rnd())
            dealerKort5 = array.GetValue(randomValue)
            dealerKortShow5 = ImgArray.GetValue(randomValue)
        End If

        If dealerKort3 = Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2)
        End If
        If dealerKort4 = Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3)
        End If
        If dealerKort5 = Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3) + Val(dealerKort4)
        End If
        If dealerKort5 <> Nothing Then
            computerTotal = Val(dealerKort1) + Val(dealerKort2) + Val(dealerKort3) + Val(dealerKort4) + Val(dealerKort5)
        End If

        'Viser antall poeng kortene til spilleren er verdt så langt
        lblPlayerScore.Text = "Dine Poeng: " & playerTotal

        'Viser trukket men skulte kort
        PictureBox6.Image = My.Resources.b1fv
        PictureBox7.Image = My.Resources.b1fv

    End Sub

    '###################### LUKKER SPILLET #######################################
    Private Sub lukkSpill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lukkSpill.Click
        Me.Close()
    End Sub

End Class
