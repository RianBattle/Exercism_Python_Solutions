dna_to_rna = {
    "G": "C",
    "C": "G",
    "T": "A",
    "A": "U"
}

def to_rna(dna_strand):
    result = [dna_to_rna[n] for n in dna_strand]
    return "".join(result)
