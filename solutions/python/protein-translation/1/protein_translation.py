CODONS = {
    "Methionine": ["AUG"],
    "Phenylalanine": ["UUU", "UUC"],
    "Leucine": ["UUA", "UUG"],
    "Serine": ["UCU", "UCC", "UCA", "UCG"],
    "Tyrosine": ["UAU", "UAC"],
    "Cysteine": ["UGU", "UGC"],
    "Tryptophan": ["UGG"],
    "STOP": ["UAA", "UAG", "UGA"]
}

def proteins(strand):
    result = []
    for i in range(0, len(strand), 3):
        input_codon = strand[i:i+3]
        if input_codon in CODONS["STOP"]:
            return result
        for amino, codons in CODONS.items():
            if input_codon in codons:
                result.append(amino)
    return result
